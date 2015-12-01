using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WingtipDataGenerator.Models;

namespace WingtipDataGenerator {
  class Program {

    static WingtipSales SalesDbContext = new WingtipSales();

    static void RecreateContext() {
      try { SalesDbContext.Dispose(); }
      catch { }

      SalesDbContext = new WingtipSales();
      SalesDbContext.Configuration.ValidateOnSaveEnabled = false;
    }

    private static Random RandomNumber = new Random(7);

    private static List<int> repeatCustomers = new List<int>();

    private static List<int> GetRepeatCustomers() {
      List<int> repeatCustomerSet = new List<int>();

      if (repeatCustomers.Count < 10) {
        return repeatCustomerSet;
      }

      int repeatCustomerCountMax = Convert.ToInt32((Math.Floor(Math.Sqrt(repeatCustomers.Count))));
      int repeatCustomerCount = RandomNumber.Next(0, repeatCustomerCountMax);

      for (int counter = 0; counter <= repeatCustomerCount; counter++) {
        int customerIndex = RandomNumber.Next(1, repeatCustomers.Count);
        repeatCustomerSet.Add(repeatCustomers[customerIndex]);
      }


      return repeatCustomerSet;
    }

    static void Main() {

      RecreateContext();
      //SalesDbContext.Configuration.AutoDetectChangesEnabled = false;
      //SalesDbContext.Configuration.ValidateOnSaveEnabled = false;

      // recreate database tables without indexes
      RebuildDatabase();



      Console.WriteLine("add products");

      foreach (ProductData product in DataFactory.GetProductsList()) {
        AddProduct(product);
      }

      Console.WriteLine("Add customers and invoices");

      DateTime runnerDate = new DateTime(2012, 1, 28);
      int customerId = AddCustomer(DataFactory.GetNextCustomer(), runnerDate);


      while (runnerDate < new DateTime(2012, 6, 18)) {
        Console.WriteLine();
        Console.Write(runnerDate.ToShortDateString());
        ProcessDayInPhase1(runnerDate);
        runnerDate = runnerDate.AddDays(1);
      }

      DataFactory.SetCustomerGrowthPhase(2);
      while (runnerDate < new DateTime(2013, 3, 15)) {
        Console.WriteLine();
        Console.Write(runnerDate.ToShortDateString());
        ProcessDayInPhase2(runnerDate);
        runnerDate = runnerDate.AddDays(1);
      }

      DataFactory.SetCustomerGrowthPhase(3);
      while (runnerDate < new DateTime(2014, 9, 10)) {
        Console.WriteLine();
        Console.Write(runnerDate.ToShortDateString());
        ProcessDayInPhase3(runnerDate);
        runnerDate = runnerDate.AddDays(1);
      }


      DataFactory.SetCustomerGrowthPhase(4);
      while (runnerDate < new DateTime(2016, 1, 1)) {
        Console.WriteLine();
        Console.Write(runnerDate.ToShortDateString());
        ProcessDayInPhase4(runnerDate);
        runnerDate = runnerDate.AddDays(1);
      }


      Console.WriteLine();
      Console.WriteLine("Create table relationships and indexes...");
      CreateDatabaseIndexes();
      Console.WriteLine();
      Console.WriteLine();
      Console.WriteLine("Sample content has been added successfully...");
      Console.WriteLine();


    }

    static void ProcessDayInPhase1(DateTime runnerDate) {
      RecreateContext();

      if ((runnerDate.DayOfWeek == DayOfWeek.Sunday) && (RandomNumber.Next(1, 100) > 15)) {
        return;
      }

      int customerCount = RandomNumber.Next(0, 12);
      for (int counter = 0; counter <= customerCount; counter++) {
        int customerId = AddCustomer(DataFactory.GetNextCustomer(), runnerDate);
        if (RandomNumber.Next(1, 100) > 80) {
          repeatCustomers.Add(customerId);
        }
      }

      foreach (var customerId in GetRepeatCustomers()) {
        AddInvoice(customerId, DataFactory.GetNextInvoice(), runnerDate);
      }


    }

    static void ProcessDayInPhase2(DateTime runnerDate) {
      RecreateContext();

      int customerCount = RandomNumber.Next(0, 18);
      for (int counter = 0; counter <= customerCount; counter++) {
        int customerId = AddCustomer(DataFactory.GetNextCustomer(), runnerDate);
        if (RandomNumber.Next(1, 100) > 70) {
          repeatCustomers.Add(customerId);
        }
      }

      foreach (var customerId in GetRepeatCustomers()) {
        AddInvoice(customerId, DataFactory.GetNextInvoice(), runnerDate);
      }

    }

    static void ProcessDayInPhase3(DateTime runnerDate) {
      RecreateContext();

      int customerCount = RandomNumber.Next(0, 42);
      for (int counter = 0; counter <= customerCount; counter++) {
        int customerId = AddCustomer(DataFactory.GetNextCustomer(), runnerDate);
        if (RandomNumber.Next(1, 100) > 65) {
          repeatCustomers.Add(customerId);
        }
      }

      foreach (var customerId in GetRepeatCustomers()) {
        AddInvoice(customerId, DataFactory.GetNextInvoice(), runnerDate);
      }

    }

    static void ProcessDayInPhase4(DateTime runnerDate) {
      RecreateContext();

      int customerCount = RandomNumber.Next(0, 55);
      for (int counter = 0; counter <= customerCount; counter++) {
        int customerId = AddCustomer(DataFactory.GetNextCustomer(), runnerDate);
        if (RandomNumber.Next(1, 100) > 65) {
          repeatCustomers.Add(customerId);
        }
      }

      foreach (var customerId in GetRepeatCustomers()) {
        AddInvoice(customerId, DataFactory.GetNextInvoice(), runnerDate);
      }

    }


    static void AddProduct(ProductData productData) {

      SalesDbContext.Products.Add(new Product {
        Title = productData.Title,
        ProductCode = productData.ProductCode,
        UnitCost = Convert.ToDecimal(productData.UnitCost),
        ListPrice = Convert.ToDecimal(productData.ListPrice),
        ProductCategory = productData.ProductCategory,
        Description = productData.ProductDescription,
        Color = productData.Color,
        MinimumAge = productData.MinimumAge,
        MaximumAge = productData.MaximumAge
      });

      SalesDbContext.SaveChanges();
      Console.Write(".");
    }

    static int AddCustomer(CustomerData customerData, DateTime CreatedDate) {

      Customer newCustomer = new Customer {
        FirstName = customerData.FirstName,
        LastName = customerData.LastName,
        Company = customerData.Company,
        EmailAddress = customerData.EmailAddress,
        WorkPhone = customerData.WorkPhone,
        HomePhone = customerData.HomePhone,
        Address = customerData.Address,
        City = customerData.City,
        State = customerData.State,
        ZipCode = customerData.ZipCode,
        Gender = customerData.Gender,
        BirthDate = customerData.BirthDate,
        FirstPurchaseDate = CreatedDate,
        LastPurchaseDate = CreatedDate
      };

      SalesDbContext.Customers.Add(newCustomer);
      SalesDbContext.SaveChanges();

      int newCustomerId = newCustomer.CustomerId;
      Console.Write(".");

      AddInvoice(newCustomerId, customerData.FirstInvoice, CreatedDate);

      return newCustomerId;
    }

    static int AddInvoice(int CustomerId, InvoiceData invoiceData, DateTime CreatedDate) {

      Invoice newInvoice = new Invoice {
        CustomerId = CustomerId,
        InvoiceDate = CreatedDate,
        InvoiceAmount = Convert.ToDecimal(invoiceData.InvoiceAmount),
        InvoiceType = invoiceData.InvoiceType
      };

      SalesDbContext.Invoices.Add(newInvoice);
      SalesDbContext.SaveChanges();

      int newInvoiceId = newInvoice.InvoiceId;

      SalesDbContext.SaveChanges();

      foreach (InvoiceDetailData invoiceDetailData in invoiceData.InvoiceDetails) {
        newInvoice.InvoiceDetails.Add(new InvoiceDetail {
          InvoiceId = newInvoiceId,
          ProductId = invoiceDetailData.ProductId,
          Quantity = invoiceDetailData.Quantity,
          SalesAmount = Convert.ToDecimal(invoiceDetailData.Price)
        });

      };

      SalesDbContext.SaveChanges();
      Console.Write(".");

      Customer customer = SalesDbContext.Customers.Find(CustomerId);
      if (customer != null) {
        customer.LastPurchaseDate = CreatedDate;
        SalesDbContext.SaveChanges();
      }

      return newInvoiceId;

    }

    static void RebuildDatabaseTables() {
      string[] cmds = {
         @"IF OBJECT_ID(N'[dbo].[FK_CustomerInvoice]', 'F') IS NOT NULL ALTER TABLE [dbo].[Invoices] DROP CONSTRAINT [FK_CustomerInvoice];",
         @"IF OBJECT_ID(N'[dbo].[FK_InvoiceInvoiceDetail]', 'F') IS NOT NULL ALTER TABLE [dbo].[InvoiceDetails] DROP CONSTRAINT [FK_InvoiceInvoiceDetail];",
         @"IF OBJECT_ID(N'[dbo].[FK_ProductInvoiceDetail]', 'F') IS NOT NULL ALTER TABLE [dbo].[InvoiceDetails] DROP CONSTRAINT [FK_ProductInvoiceDetail];",
         @"IF OBJECT_ID(N'[dbo].[Customers]', 'U') IS NOT NULL DROP TABLE [dbo].[Customers];",
         @"IF OBJECT_ID(N'[dbo].[Invoices]', 'U') IS NOT NULL DROP TABLE [dbo].[Invoices];",
         @"IF OBJECT_ID(N'[dbo].[InvoiceDetails]', 'U') IS NOT NULL DROP TABLE [dbo].[InvoiceDetails];",
         @"IF OBJECT_ID(N'[dbo].[Products]', 'U') IS NOT NULL DROP TABLE [dbo].[Products];",
         @"CREATE TABLE [dbo].[Customers] ([CustomerId] int IDENTITY(1,1) NOT NULL,[FirstName] nvarchar(max)  NOT NULL,   [LastName] nvarchar(max)  NOT NULL,[Company] nvarchar(max)  NULL,[EmailAddress] nvarchar(max)  NULL,[WorkPhone] nvarchar(max)  NULL,[HomePhone] nvarchar(max)  NOT NULL,[Address] nvarchar(max)  NULL,[City] nvarchar(max)  NULL,[State] nvarchar(max)  NULL,[ZipCode] nvarchar(max)  NULL,[Gender] nvarchar(1)  NULL,[BirthDate] datetime  NOT NULL,[FirstPurchaseDate] datetime  NULL,[LastPurchaseDate] datetime  NULL);",
         @"CREATE TABLE [dbo].[Invoices] ([InvoiceId] int IDENTITY(1,1) NOT NULL, [InvoiceNumber] nvarchar(max)  NULL, [InvoiceDate] datetime  NOT NULL, [InvoiceAmount] decimal(9,2)  NOT NULL, [InvoiceType] nvarchar(max)  NOT NULL, [CustomerId] int  NOT NULL);",
         @"CREATE TABLE [dbo].[InvoiceDetails] ([Id] int IDENTITY(1,1) NOT NULL, [Quantity] int  NOT NULL, [SalesAmount] decimal(9,2)  NOT NULL, [InvoiceId] int  NOT NULL, [ProductId] int  NOT NULL );",
         @"CREATE TABLE [dbo].[Products] ([ProductId] int IDENTITY(1,1) NOT NULL,[ProductCode] nvarchar(max)  NOT NULL,[Title] nvarchar(max)  NOT NULL,[Description] nvarchar(max)  NULL,[ProductCategory] nvarchar(max)  NULL,[UnitCost] decimal(9,2)  NULL,[ListPrice] decimal(9,2)  NOT NULL,[Color] nvarchar(max)  NULL,[MinimumAge] int  NULL,[MaximumAge] int  NULL);"
        };

      foreach (string cmd in cmds) {
        try { SalesDbContext.Database.ExecuteSqlCommand(cmd); }
        catch { }
      }

    }

    static void RebuildDatabase() {


      string[] cmds = {
         @"IF OBJECT_ID(N'[dbo].[FK_CustomerInvoice]', 'F') IS NOT NULL ALTER TABLE [dbo].[Invoices] DROP CONSTRAINT [FK_CustomerInvoice];",
         @"IF OBJECT_ID(N'[dbo].[FK_InvoiceInvoiceDetail]', 'F') IS NOT NULL ALTER TABLE [dbo].[InvoiceDetails] DROP CONSTRAINT [FK_InvoiceInvoiceDetail];",
         @"IF OBJECT_ID(N'[dbo].[FK_ProductInvoiceDetail]', 'F') IS NOT NULL ALTER TABLE [dbo].[InvoiceDetails] DROP CONSTRAINT [FK_ProductInvoiceDetail];",
         @"IF OBJECT_ID(N'[dbo].[Customers]', 'U') IS NOT NULL DROP TABLE [dbo].[Customers];",
         @"IF OBJECT_ID(N'[dbo].[Invoices]', 'U') IS NOT NULL DROP TABLE [dbo].[Invoices];",
         @"IF OBJECT_ID(N'[dbo].[InvoiceDetails]', 'U') IS NOT NULL DROP TABLE [dbo].[InvoiceDetails];",
         @"IF OBJECT_ID(N'[dbo].[Products]', 'U') IS NOT NULL DROP TABLE [dbo].[Products];",
         @"CREATE TABLE [dbo].[Customers] ([CustomerId] [int] NOT NULL IDENTITY, [FirstName] [nvarchar](max), [LastName] [nvarchar](max), [Company] [nvarchar](max), [EmailAddress] [nvarchar](max), [WorkPhone] [nvarchar](max), [HomePhone] [nvarchar](max), [Address] [nvarchar](max), [City] [nvarchar](max), [State] [nvarchar](max), [ZipCode] [nvarchar](max), [Gender] [nvarchar](max), [BirthDate] [datetime] NOT NULL, [FirstPurchaseDate] [datetime], [LastPurchaseDate] [datetime], CONSTRAINT [PK_dbo.Customers] PRIMARY KEY ([CustomerId]) )",
         @"CREATE TABLE [dbo].[Invoices] ([InvoiceId] [int] NOT NULL IDENTITY, [InvoiceDate] [datetime] NOT NULL, [InvoiceAmount] [decimal](18, 2) NOT NULL, [InvoiceType] [nvarchar](max), [CustomerId] [int] NOT NULL, CONSTRAINT [PK_dbo.Invoices] PRIMARY KEY ([InvoiceId]) )",
         @"CREATE TABLE [dbo].[InvoiceDetails] ([Id] [int] NOT NULL IDENTITY, [Quantity] [int] NOT NULL, [SalesAmount] [decimal](18, 2) NOT NULL, [InvoiceId] [int] NOT NULL, [ProductId] [int] NOT NULL, CONSTRAINT [PK_dbo.InvoiceDetails] PRIMARY KEY ([Id]) )",
         @"CREATE TABLE [dbo].[Products] ([ProductId] [int] NOT NULL IDENTITY, [ProductCode] [nvarchar](max), [Title] [nvarchar](max), [Description] [nvarchar](max), [ProductCategory] [nvarchar](max), [UnitCost] [decimal](18, 2), [ListPrice] [decimal](18, 2) NOT NULL, [Color] [nvarchar](max), [MinimumAge] [int], [MaximumAge] [int], CONSTRAINT [PK_dbo.Products] PRIMARY KEY ([ProductId]) )",
         @"CREATE INDEX [IX_CustomerId] ON [dbo].[Invoices]([CustomerId])",
         @"CREATE INDEX [IX_InvoiceId] ON [dbo].[InvoiceDetails]([InvoiceId])",
         @"CREATE INDEX [IX_ProductId] ON [dbo].[InvoiceDetails]([ProductId])",
         @"ALTER TABLE [dbo].[Invoices] ADD CONSTRAINT [FK_CustomerInvoice] FOREIGN KEY ([CustomerId]) REFERENCES [dbo].[Customers] ([CustomerId]) ON DELETE CASCADE",
         @"ALTER TABLE [dbo].[InvoiceDetails] ADD CONSTRAINT [FK_InvoiceInvoiceDetail] FOREIGN KEY ([InvoiceId]) REFERENCES [dbo].[Invoices] ([InvoiceId]) ON DELETE CASCADE",
         @"ALTER TABLE [dbo].[InvoiceDetails] ADD CONSTRAINT [FK_ProductInvoiceDetail] FOREIGN KEY ([ProductId]) REFERENCES [dbo].[Products] ([ProductId]) ON DELETE CASCADE",
        };


      foreach (string cmd in cmds) {
        try { SalesDbContext.Database.ExecuteSqlCommand(cmd); }
        catch { }
      }

    }

    static void CreateDatabaseIndexes() {
      string[] cmds = {
         @"ALTER TABLE [dbo].[Customers] ADD CONSTRAINT [PK_Customers] PRIMARY KEY CLUSTERED ([Id] ASC);",
         @"ALTER TABLE [dbo].[Invoices] ADD CONSTRAINT [PK_Invoices] PRIMARY KEY CLUSTERED ([Id] ASC);",
         @"ALTER TABLE [dbo].[InvoiceDetails] ADD CONSTRAINT [PK_InvoiceDetails] PRIMARY KEY CLUSTERED ([Id] ASC);",
         @"ALTER TABLE [dbo].[Products] ADD CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED ([Id] ASC);",
         @"ALTER TABLE [dbo].[Invoices] ADD CONSTRAINT [FK_CustomerInvoice] FOREIGN KEY ([CustomerId]) REFERENCES [dbo].[Customers]([Id]) ON DELETE NO ACTION ON UPDATE NO ACTION;",
         @"CREATE INDEX [IX_FK_CustomerInvoice] ON [dbo].[Invoices] ([CustomerId]);",
         @"ALTER TABLE [dbo].[InvoiceDetails] ADD CONSTRAINT [FK_InvoiceInvoiceDetail] FOREIGN KEY ([InvoiceId]) REFERENCES [dbo].[Invoices] ([Id]) ON DELETE NO ACTION ON UPDATE NO ACTION;",
         @"CREATE INDEX [IX_FK_InvoiceInvoiceDetail] ON [dbo].[InvoiceDetails] ([InvoiceId]);",
         @"ALTER TABLE [dbo].[InvoiceDetails] ADD CONSTRAINT [FK_ProductInvoiceDetail] FOREIGN KEY ([ProductId]) REFERENCES [dbo].[Products] ([Id]) ON DELETE NO ACTION ON UPDATE NO ACTION;",
         @"CREATE INDEX [IX_FK_ProductInvoiceDetail] ON [dbo].[InvoiceDetails] ([ProductId]);"
        };

      foreach (string cmd in cmds) {
        try { SalesDbContext.Database.ExecuteSqlCommand(cmd); }
        catch { }
      }

    }
  }
}
