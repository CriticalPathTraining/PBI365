# create vector
myVector <- 1:12
print(myVector)

# create matrix
myMatrix <- matrix(1:12, ncol = 3 , nrow = 4)
print(myMatrix)

# create 3D array
my3DArray = array(1:12, dim = c(2,2,3) )
print(my3DArray)

# create list
myList <- list(Name="Ted", 
               Age=53, 
               Kids=c("Sophie", "Daisy", "Annabelle"))
print(myList)

# reference list element using $ operator
myList$Age

# create dataframe
myDataframe = data.frame(
  Year = c(2014, 2014, 2015, 2015),
  Region = c("West", "East", "West", "East"),
  Sales = c(212, 108, 240, 218)
)

# create factor
myFactor = factor(myDataframe$Region, levels = c("West", "East") )

