SELECT 
  CustomerId, 
  FirstName + N' ' + LastName AS Customer, 
  CASE Gender
    WHEN 'F' THEN 'Female'
    WHEN 'M' THEN 'Male'
  END AS Gender,
  State, 
  City + N', ' + State AS City, 
  Zipcode
FROM Customers