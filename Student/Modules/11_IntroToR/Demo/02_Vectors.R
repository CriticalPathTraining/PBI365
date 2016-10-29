# create vector with numeric values
myVector <- c(34, 56, 39, 60, 44, 38)
print(myVector)

# provide names for vector elements
names(myVector) = c("JUL", "AUG", "SEP", "OCT", "NOV", "DEC")
print(myVector)

# perform vector operation
myVector <- myVector * 2

# select subset by specifying values to include
myVector[c(1, 3, 5)]

# select subset by specifying values to exclude with (-)
myVector[-c(1, 3, 5)]

# perform vector operations
length(myVector)
sum(myVector)
diff(myVector)
sort(myVector)

# determine indexes for elements with value over 100 
which(myVector>100)

# get all elements with value over 100
myVector[ which(myVector>100) ]

# update one element inside vector changes mode type
myVector[2] = "rosebud"

# error - cannot perform math operation on string-based vector
myVector * 2

