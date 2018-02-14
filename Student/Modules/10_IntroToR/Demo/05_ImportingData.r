urlData = "https://github.com/CriticalPathTraining/PBI365/raw/master/Student/Data/SalesByCustomer.csv"
customers <- read.csv(urlData)

# give columns prettier names
names(customers) = c("Customer","State","Gender","Age","Sales")

# Gender single charactor values

# install packages if they are not installed
if(!('plyr' %in% rownames(installed.packages()))){
  install.packages("plyr")
}

library(plyr)
customers$Gender <- mapvalues(customers$Gender, from = c("Male", "Female"), to = c("M", "F"))


# sort the data
customers <- customers[ order(customers$Age, decreasing=TRUE),  ]


florida.customers = subset(customers, State == "FL", c("Customer", "Age") )

hist(florida.customers$Age, 
     main = "Florida Customer Count by Age",
     col="lightblue", 
     border="black",
     ylab="Customer Count", 
     xlab="Customer Age",
     xlim = c(20, 100),
     breaks=50 )

