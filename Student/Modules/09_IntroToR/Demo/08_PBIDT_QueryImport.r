# import data
customers <- read.csv("https://github.com/CriticalPathTraining/IntroToR/raw/master/SalesByCustomer.csv")

# give columns prettier names
names(customers) = c("Customer","State","Gender","Age","Sales")

# sort the data
customers <- customers[ order(customers$Age, decreasing=TRUE),  ]


florida.customers = subset(customers, State == "FL", c("Customer", "Gender", "Age", "Sales") )
texas.customers = subset(customers, State == "TX", c("Customer", "Gender", "Age", "Sales") )
california.customers = subset(customers, State == "CA", c("Customer", "Gender", "Age", "Sales") )

rm(customers)

