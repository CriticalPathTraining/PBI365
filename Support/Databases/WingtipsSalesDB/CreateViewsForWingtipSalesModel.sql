USE [WingtipSalesDB]
GO

DROP VIEW [view_CustomerDimension]
DROP VIEW [view_ProductDimension]
DROP VIEW [view_PurchaseDimension]
DROP VIEW [view_ProductSalesFacts]
GO

CREATE VIEW [view_CustomerDimension]
AS
SELECT        
  Customers.CustomerId, 
  Customers.State,
  Customers.City, 
  Customers.Zipcode, 
  Customers.Gender
FROM            
  Customers

GO

CREATE VIEW [view_ProductDimension]
AS
SELECT        
  ProductId, 
  LEFT(ProductCategory, CHARINDEX(' >', ProductCategory) - 1) AS Category, 
  RIGHT(ProductCategory, LEN(ProductCategory) - CHARINDEX('>', ProductCategory)) AS Subcategory, 
  Title AS Product,
  ProductImageUrl
FROM            
  Products

GO


CREATE VIEW [view_PurchaseDimension]
AS
SELECT        
  InvoiceId, 
  InvoiceType AS [Purchase Type]
FROM            
  Invoices

GO

CREATE VIEW [view_ProductSalesFacts]
AS
SELECT        
  InvoiceDetails.Id, 
  InvoiceDetails.InvoiceId, 
  InvoiceDetails.ProductId, 
  Invoices.CustomerId, 
  InvoiceDate, 
  InvoiceDetails.Quantity, 
  InvoiceDetails.SalesAmount, 
  Products.UnitCost * InvoiceDetails.Quantity AS [ProductCost]
FROM            
  Invoices 
    INNER JOIN InvoiceDetails ON Invoices.InvoiceId = InvoiceDetails.InvoiceId 
    INNER JOIN Products ON InvoiceDetails.ProductId = Products.ProductId

GO

