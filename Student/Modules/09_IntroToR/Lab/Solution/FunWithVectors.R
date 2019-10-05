averageTempature <- c(74, 80, 64, 52, 36, 28)
print(averageTempature)

names(averageTempature) = c("JUL", "AUG", "SEP", "OCT", "NOV", "DEC")
print(averageTempature)

averageTempatureQ3 = averageTempature[c(1, 2, 3)]
print(averageTempatureQ3)

averageTempatureQ4 = averageTempature[-c(1, 2, 3)]
print(averageTempatureQ4)

coldMonths = averageTempature[averageTempature<50]
print(coldMonths)

averageTempatureCelsius <- (averageTempature-32) * (5/9)
print(averageTempatureCelsius)

averageTempatureCelsius <- round( (averageTempature-32) * (5/9), 0)
print(averageTempatureCelsius)
