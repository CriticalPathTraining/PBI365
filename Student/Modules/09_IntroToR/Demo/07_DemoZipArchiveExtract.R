
# create temp file
temp <- tempfile()

# download zip archive to temp file
urlZipArchive = "https://github.com/CriticalPathTraining/PBI365/raw/master/Student/Data/SalesData.zip"
download.file(urlZipArchive ,temp)

# extract CSV file out of zip
csvFile = unz(temp, "SalesByCustomer.csv")

# load new data frame from data in CSV file 
customers <- read.csv(csvFile)

# perform cleanup 
unlink(temp)
remove(csvFile)
remove(temp)
remove(urlZipArchive)