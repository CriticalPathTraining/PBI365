# 'dataset' holds the input data for this script
# filter the data 
dataset <- subset(dataset, (Age<=65) & (Age>60) & (Gender=="Male") )

# sort the data
dataset <- dataset [ order(dataset$Age),  ]

# add plyr package and use it replace values
library(plyr)
dataset$Gender <- mapvalues(dataset$Gender, from = c("Male", "Female"), to = c("M", "F"))

# send dataset to query step output
output <- dataset