
#  Creating vectors
a <- c(1, 2, 5, 3, 6, -2, 4)
b <- c("apple", "bannanna", "chery")
c <- c(TRUE, TRUE, TRUE, FALSE, TRUE, FALSE)

# clear all objects from memory
rm(list=objects())

# Using vector subscripts
d  <- c(2, 4, 6, 8)

d[3]

d[8] = 20
d

d[5] = "Hello"
d

