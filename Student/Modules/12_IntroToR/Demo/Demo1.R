message <- "Hello World"
message

# create a dataset
x <- pretty(c(-3, 3), 100)
y <- dnorm(x)

# plot the dataset
plot(x, y,
     xlab="Normal Deviation",
     ylab = "Density",
     yaxs="i")

