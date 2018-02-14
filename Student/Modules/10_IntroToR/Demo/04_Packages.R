
# install packages if they are not installed
if(!('tidyr' %in% rownames(installed.packages()))){
  install.packages("tidyr")
}

if(!('dplyr' %in% rownames(installed.packages()))){
  install.packages("dplyr")
}

if(!('ggplot2' %in% rownames(installed.packages()))){
  install.packages("ggplot2")
}

# load packages into workspace
library(tidyr)
library(dplyr)
library(ggplot2)

# unload packages from workspace
detach("package:tidyr", unload = TRUE)
detach("package:dplyr", unload = TRUE)
detach("package:ggplot2", unload = TRUE)

