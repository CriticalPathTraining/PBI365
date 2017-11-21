SELECT
  CustomerId, 
  ProductId, 
  Cast(InvoiceDate As date) AS [Purchase Date], 
  Year(InvoiceDate) As [Purchase Year],
  Quantity, 
  SalesAmount,
  CASE InvoiceType
    WHEN 'InPerson' THEN 'Store Transaction'
    WHEN 'MailOrder' THEN 'Mail Order Transaction'
    WHEN 'Online' THEN 'Online Transaction'
  END AS [Purchase Type]
FROM InvoiceDetails INNER JOIN Invoices 
  ON InvoiceDetails.InvoiceId = Invoices.InvoiceId