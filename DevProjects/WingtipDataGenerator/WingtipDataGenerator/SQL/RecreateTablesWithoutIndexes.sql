
IF OBJECT_ID(N'[dbo].[FK_CustomerInvoices]', 'F') IS NOT NULL ALTER TABLE [Invoices] DROP CONSTRAINT [FK_CustomerInvoices];
IF OBJECT_ID(N'[dbo].[FK_InvoiceInvoiceDetails]', 'F') IS NOT NULL ALTER TABLE [InvoiceDetails] DROP CONSTRAINT [FK_InvoiceInvoiceDetails];
IF OBJECT_ID(N'[dbo].[FK_ProductInvoiceDetails]', 'F') IS NOT NULL ALTER TABLE [InvoiceDetails] DROP CONSTRAINT [FK_ProductInvoiceDetails];
IF OBJECT_ID(N'[dbo].[Customers]', 'U') IS NOT NULL DROP TABLE [Customers];
IF OBJECT_ID(N'[dbo].[Invoices]', 'U') IS NOT NULL DROP TABLE [Invoices];
IF OBJECT_ID(N'[dbo].[InvoiceDetails]', 'U') IS NOT NULL DROP TABLE [InvoiceDetails];
IF OBJECT_ID(N'[dbo].[Products]', 'U') IS NOT NULL DROP TABLE [Products];


CREATE TABLE [Customers] (
  [CustomerId] [int] NOT NULL IDENTITY, 
  [FirstName] [nvarchar](max), 
  [LastName] [nvarchar](max), 
  [Company] [nvarchar](max), 
  [EmailAddress] [nvarchar](max), 
  [WorkPhone] [nvarchar](max), 
  [HomePhone] [nvarchar](max), 
  [Address] [nvarchar](max), 
  [City] [nvarchar](max), 
  [State] [nvarchar](max), 
  [ZipCode] [nvarchar](max), 
  [Gender] [nvarchar](max), 
  [BirthDate] [datetime] NOT NULL, 
  [FirstPurchaseDate] [datetime], 
  [LastPurchaseDate] [datetime]
)

CREATE TABLE [Invoices] (
  [InvoiceId] [int] NOT NULL IDENTITY, 
  [InvoiceDate] [datetime] NOT NULL, 
  [InvoiceAmount] [decimal](18, 2) NOT NULL, 
  [InvoiceType] [nvarchar](max), 
  [CustomerId] [int] NOT NULL
)

CREATE TABLE [InvoiceDetails] (
  [Id] [int] NOT NULL IDENTITY, 
  [Quantity] [int] NOT NULL, 
  [SalesAmount] [decimal](18, 2) NOT NULL, 
  [InvoiceId] [int] NOT NULL, 
  [ProductId] [int] NOT NULL
)

CREATE TABLE [Products] (
  [ProductId] [int] NOT NULL IDENTITY, 
  [ProductCode] [nvarchar](max), 
  [Title] [nvarchar](max), 
  [Description] [nvarchar](max), 
  [ProductCategory] [nvarchar](max), 
  [UnitCost] [decimal](18, 2), 
  [ListPrice] [decimal](18, 2) NOT NULL, 
  [Color] [nvarchar](max), 
  [MinimumAge] [int], 
  [MaximumAge] [int]
)
