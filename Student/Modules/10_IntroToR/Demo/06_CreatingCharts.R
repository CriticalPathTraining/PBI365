rm(list=objects())

# create normal distribution of sample data
data <- rnorm(1000)

# create histogram
hist(data)

# create boxplot
boxplot(data)

# create Q-Q plot
qqnorm(data)

# create scatter plot
plot(data)

# create 2x2 chart frame
par(mfrow = c(2, 2))
  hist(data)
  boxplot(data)
  qqnorm(data)
  plot(data)


# create non-default output device to generate PDF file
png("MyChart.png")
  par(mfrow = c(2, 2))
    hist(data)
    boxplot(data)
    qqnorm(data)
    plot(data)
dev.off()
