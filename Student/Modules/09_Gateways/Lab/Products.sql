SELECT        
  ProductId, 
  LEFT(ProductCategory, CHARINDEX(' >', ProductCategory) - 1) AS Category, 
  RIGHT(ProductCategory, LEN(ProductCategory) - CHARINDEX('>', ProductCategory)) AS Subcategory, 
  Title AS Product,
  ProductImageUrl As [Product Image]
FROM            
  Products