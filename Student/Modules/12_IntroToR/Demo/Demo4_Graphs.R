install.packages("lattice")

data <- rnorm(1000)

hist(data)


boxplot(data)


qqnorm(data)


plot(data)

par(mfrow = c(2, 2))
hist(data)
boxplot(data)
qqnorm(data)
plot(data)



png("MyChart.png")
  par(mfrow = c(2, 2))
    hist(data)
    boxplot(data)
    qqnorm(data)
    plot(data)
dev.off()


