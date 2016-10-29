# use <- for variable assignment
message <- "Hello World"

print(message)

# create vector using the c function
vector1 <- c(2, 4, 6,  8)

# create vectors using sequence
vector2 <- 1:10
vector3 = letters[1:5]
vector4 = LETTERS[24:26]
vector6 = 2^(1:8)

# create vector with electin years
election.years <- seq(from = 1996, to = 2016, by = 4)

# enumerate through election years using for loop
for (year in election.years){
    print(paste(year, "is an election year"))
}

# remove all objects from workspace
rm(list=objects())









