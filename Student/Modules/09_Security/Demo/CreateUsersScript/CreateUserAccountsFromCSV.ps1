Clear-Host 

# update the next three lines with values from your Office 365 tenant
$classroomDomainName = "myTenant"
$globalAdminAccountName = "student"
$globalAdminPassword = "pass@word1"

$classroomDomain = $classroomDomainName + ".onMicrosoft.com"
$classroomSharePointRootSite = "https://" + $classroomDomainName + ".sharepoint.com"
$classroomSharePointTenantSite = "https://" + $classroomDomainName + "-admin.sharepoint.com"

$globalAdminAccount = $globalAdminAccountName + "@" + $classroomDomain 
$globalAdminSecurePassword = ConvertTo-SecureString -String $globalAdminPassword -AsPlainText -Force

$e5LcenseSku = $classroomDomainName + ":ENTERPRISEPREMIUM"


function New-User($firstName, $lastName, $alternateEmail) {

 $displayName = $firstName + " " + $lastName

 $firstNameClean = $firstName -replace " ", ""
 $firstNameClean = $firstNameClean -replace "'", ""
 
 $lastNameClean = $lastName -replace " ", ""
 $lastNameClean = $lastNameClean -replace "'", ""

 $mailNickname = $firstNameClean + $lastNameClean.SubString(0,1)
 $userPrincipalName =  $mailNickname + "@" + $classroomDomain

 $password = "pass@word1"
 $passwordProfile = New-Object -TypeName Microsoft.Open.AzureAD.Model.PasswordProfile
 $passwordProfile.Password = $password
 $passwordProfile.ForceChangePasswordNextLogin = $false
 $passwordProfile.EnforceChangePasswordPolicy = $false

 $secureStringPassword = ConvertTo-SecureString -String "pass@word1" -AsPlainText -Force
 
 # Create new user account for student 
 $newUser = New-AzureADUser `
                -DisplayName $displayName `
                -GivenName $firstName `
                -Surname $lastName `
                -MailNickName $mailNickname `
                -PasswordProfile $passwordProfile `
                -PasswordPolicies "DisablePasswordExpiration, DisableStrongPassword" `
                -UserPrincipalName $userPrincipalName `
                -UsageLocation "US" `
                -AccountEnabled $True


 $licenseSkuPartNumber = 'ENTERPRISEPREMIUM'
 $LicenseSku = Get-AzureADSubscribedSku | Where-Object {$_.SkuPartNumber -eq $licenseSkuPartNumber } 
 
 #Create the AssignedLicense object with the License and DisabledPlans earlier created
 $License = New-Object -TypeName Microsoft.Open.AzureAD.Model.AssignedLicense
 $License.SkuId = $LicenseSku.SkuId
 
 #Create the AssignedLicenses Object 
 $AssignedLicenses = New-Object -TypeName Microsoft.Open.AzureAD.Model.AssignedLicenses
 $AssignedLicenses.AddLicenses = $License
 $AssignedLicenses.RemoveLicenses = @()

 #Assign the license to the user
 Set-AzureADUserLicense -ObjectId $newUser.ObjectId -AssignedLicenses $AssignedLicenses

 # write user info for student to log file
 "User: $userDisplayName" | Out-File $LogFilePath -Append
 "Login: $userPrincipalName" | Out-File $LogFilePath -Append
 "Password: $password" | Out-File $LogFilePath -Append
 "Alt Email: $alternateEmail" | Out-File $LogFilePath -Append
 "" | Out-File $LogFilePath -Append
 "" | Out-File $LogFilePath -Append

}

# create new log file 
$CurrentDirectory = Get-Location 
$LogFilePath = ("{0}\UsersLog.txt" -f $PSScriptRoot)
"Log of created user accounts" | Out-File $LogFilePath
"" | Out-File $LogFilePath -Append

$credential = New-Object -TypeName System.Management.Automation.PSCredential `
                         -ArgumentList $globalAdminAccount, $globalAdminSecurePassword

Connect-AzureAD  -Credential $credential

$UserDataFilePath = ("{0}\UserData.csv" -f $PSScriptRoot)
$Users = Import-csv -path $UserDataFilePath

foreach($User in $Users) { 
   New-User $User.FirstName $User.LastName $User.AlternateEmail 
}
