
# create a reusable function 
barpercent <- function (x, names = NULL, col = "lightblue") {
  # this code orginally written by Naomi b. Robbins
  if (is.null(names)) names <- names(x)
  par (las = 1, mar = c(5,10,4,6), xpd = NA, xaxs = "i", yaxs= "i")
  data <- x[order(x)]*100/sum(x)
  labels <- paste(names[order(x)],"   ",formatC(data,digits=1,format="f",width=4))
  xmax <- round(max(data),digits = -1)
  ymax <- (length(x)*1.2)+.1
  plot(NULL, xlim = c(0,xmax), ylim=c(0,ymax), axes = FALSE, xlab = "percent", ylab="")
  barplot(data, horiz = TRUE, names.arg = labels, col = col, border = col, axes = FALSE, add = TRUE)
  axis (1, pos = 0, xlim = c(0,xmax), at = c(0,1:(xmax/10)*10))
  hat <- -xmax/16.66667
  text(hat, .2, "100.0", adj = c(1,1))
  text(hat, .2, "%", adj = c(0,1))
  lines(c(.3,3.2)*hat,c(.25,.25))
}

# now write some code which uses the function

region<- factor(c("Western Region",
                  "Central Region", 
                  "Eastern Region"))

regionSales <- c(342, 246, 363)


barpercent(regionSales, region, col="red")

