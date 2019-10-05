

regions <- factor(c("Western Region",
                    "Central Region", 
                    "Eastern Region"))

regionSales <- c(342, 246, 363)

sales <- data.frame(
  Region = regions, 
  Sales = regionSales
)

pie(sales$Sales, labels = regions)

