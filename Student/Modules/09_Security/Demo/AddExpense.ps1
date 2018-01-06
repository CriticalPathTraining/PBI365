
$endpoint = "https://api.powerbi.com/beta/1b19bca7-14a6-40d4-b8f7-b26609958baf/datasets/7941e0da-c2d4-47de-b3fb-b0c37474df02/rows?key=mJO15AqhdX178uVWx7eF6Hc9Yo%2FiLC3iEH%2FnqnzwXRjA%2Be6N7gU5ljnHz73b1z10E1cFTYSWyM2y2Aa8SXDxyQ%3D%3D"

$payload = @{
"Category" ="Hardware"
"Amount" = 345.34
"Date" ="2017-12-06T14:25:44.981Z"
}

Invoke-RestMethod -Method Post -Uri "$endpoint" -Body (ConvertTo-Json @($payload))