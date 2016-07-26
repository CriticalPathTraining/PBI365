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
      RebuildDatabaseTables();



      Console.WriteLine("add products");

      foreach (ProductData product in DataFactory.GetProductsList()) {
        AddProduct(product);
      }

      Console.WriteLine("Add customers and invoices");

      DateTime runnerDate = new DateTime(2012, 1, 28);
      int customerId = AddCustomer(DataFactory.GetNextCustomer(), runnerDate);

      while (runnerDate < new DateTime(2012, 5, 12)) {
        Console.WriteLine();
        Console.Write(runnerDate.ToShortDateString());
        ProcessDayInPhase1(runnerDate);
        runnerDate = runnerDate.AddDays(1);
      }

      DataFactory.SetCustomerGrowthPhase(2);
      while (runnerDate < new DateTime(2012, 8, 20)) {
        Console.WriteLine();
        Console.Write(runnerDate.ToShortDateString());
        ProcessDayInPhase2(runnerDate);
        runnerDate = runnerDate.AddDays(1);
      }

      DataFactory.SetCustomerGrowthPhase(3);
      while (runnerDate < new DateTime(2012, 10, 20)) {
        Console.WriteLine();
        Console.Write(runnerDate.ToShortDateString());
        ProcessDayInPhase3(runnerDate);
        runnerDate = runnerDate.AddDays(1);
      }


      DataFactory.SetCustomerGrowthPhase(4);
      while (runnerDate < new DateTime(2013, 1, 10)) {
        Console.WriteLine();
        Console.Write(runnerDate.ToShortDateString());
        ProcessDayInPhase4(runnerDate);
        runnerDate = runnerDate.AddDays(1);
      }

      DataFactory.SetCustomerGrowthPhase(5);
      while (runnerDate < new DateTime(2013, 5, 30)) {
        Console.WriteLine();
        Console.Write(runnerDate.ToShortDateString());
        ProcessDayInPhase5(runnerDate);
        runnerDate = runnerDate.AddDays(1);
      }

      DataFactory.SetCustomerGrowthPhase(6);
      while (runnerDate < new DateTime(2013, 8, 5)) {
        Console.WriteLine();
        Console.Write(runnerDate.ToShortDateString());
        ProcessDayInPhase6(runnerDate);
        runnerDate = runnerDate.AddDays(1);
      }

      DataFactory.SetCustomerGrowthPhase(7);
      while (runnerDate < new DateTime(2013, 11, 20)) {
        Console.WriteLine();
        Console.Write(runnerDate.ToShortDateString());
        ProcessDayInPhase7(runnerDate);
        runnerDate = runnerDate.AddDays(1);
      }

      DataFactory.SetCustomerGrowthPhase(8);
      while (runnerDate < new DateTime(2014, 2, 10)) {
        Console.WriteLine();
        Console.Write(runnerDate.ToShortDateString());
        ProcessDayInPhase8(runnerDate);
        runnerDate = runnerDate.AddDays(1);
      }

      DataFactory.SetCustomerGrowthPhase(9);
      while (runnerDate < new DateTime(2014, 6, 20)) {
        Console.WriteLine();
        Console.Write(runnerDate.ToShortDateString());
        ProcessDayInPhase9(runnerDate);
        runnerDate = runnerDate.AddDays(1);
      }

      DataFactory.SetCustomerGrowthPhase(10);
      while (runnerDate < new DateTime(2014, 8, 15)) {
        Console.WriteLine();
        Console.Write(runnerDate.ToShortDateString());
        ProcessDayInPhase10(runnerDate);
        runnerDate = runnerDate.AddDays(1);
      }

      DataFactory.SetCustomerGrowthPhase(11);
      while (runnerDate < new DateTime(2014, 11, 15)) {
        Console.WriteLine();
        Console.Write(runnerDate.ToShortDateString());
        ProcessDayInPhase11(runnerDate);
        runnerDate = runnerDate.AddDays(1);
      }

      DataFactory.SetCustomerGrowthPhase(12);
      while (runnerDate < new DateTime(2015, 3, 1)) {
        Console.WriteLine();
        Console.Write(runnerDate.ToShortDateString());
        ProcessDayInPhase12(runnerDate);
        runnerDate = runnerDate.AddDays(1);
      }

      DataFactory.SetCustomerGrowthPhase(13);
      while (runnerDate < new DateTime(2015, 6, 10)) {
        Console.WriteLine();
        Console.Write(runnerDate.ToShortDateString());
        ProcessDayInPhase13(runnerDate);
        runnerDate = runnerDate.AddDays(1);
      }

      DataFactory.SetCustomerGrowthPhase(14);
      while (runnerDate < new DateTime(2015, 8, 15)) {
        Console.WriteLine();
        Console.Write(runnerDate.ToShortDateString());
        ProcessDayInPhase14(runnerDate);
        runnerDate = runnerDate.AddDays(1);
      }

      DataFactory.SetCustomerGrowthPhase(15);
      while (runnerDate < new DateTime(2015, 10, 15)) {
        Console.WriteLine();
        Console.Write(runnerDate.ToShortDateString());
        ProcessDayInPhase15(runnerDate);
        runnerDate = runnerDate.AddDays(1);
      }

      DataFactory.SetCustomerGrowthPhase(16);
      while (runnerDate < new DateTime(2016, 1, 1)) {
        Console.WriteLine();
        Console.Write(runnerDate.ToShortDateString());
        ProcessDayInPhase16(runnerDate);
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
      if ((runnerDate.DayOfWeek == DayOfWeek.Sunday) && (RandomNumber.Next(1, 100) > 40)) {
        return;
      }

      int customerCount = RandomNumber.Next(3, 32);
      for (int counter = 0; counter <= customerCount; counter++) {
        int customerId = AddCustomer(DataFactory.GetNextCustomer(), runnerDate);
        if (RandomNumber.Next(1, 100) > 78) {
          repeatCustomers.Add(customerId);
        }
      }

      foreach (var customerId in GetRepeatCustomers()) {
        AddInvoice(customerId, DataFactory.GetNextInvoice(), runnerDate);
      }

    }

    static void ProcessDayInPhase3(DateTime runnerDate) {
      RecreateContext();

      int customerCount = RandomNumber.Next(10, 40);
      for (int counter = 0; counter <= customerCount; counter++) {
        int customerId = AddCustomer(DataFactory.GetNextCustomer(), runnerDate);
        if (RandomNumber.Next(1, 100) > 92) {
          repeatCustomers.Add(customerId);
        }
      }

      foreach (var customerId in GetRepeatCustomers()) {
        AddInvoice(customerId, DataFactory.GetNextInvoice(), runnerDate);
      }
    }

    static void ProcessDayInPhase4(DateTime runnerDate) {
      RecreateContext();

      int customerCount = RandomNumber.Next(12, 52);
      if (runnerDate.Equals(new DateTime(2012, 11, 23))){
        customerCount = 228;
      }
      if (runnerDate.Equals(new DateTime(2012, 11, 26))) {
        customerCount = 198;
      }

      if (runnerDate.Month.Equals(12)) {
        if (runnerDate.Day < 6) {
          customerCount += 25;
        }
        else if (runnerDate.Day < 12) {
          customerCount += 32;
        }
        else if (runnerDate.Day < 18) {
          customerCount += 44;
        }
        else if (runnerDate.Day < 24) {
          customerCount += 15;
        }
        else if (runnerDate.Day < 30) {
          customerCount -= 45;
        }
      }

      for (int counter = 0; counter <= customerCount; counter++) {
        int customerId = AddCustomer(DataFactory.GetNextCustomer(), runnerDate);
        if (RandomNumber.Next(1, 100) > 85) {
          repeatCustomers.Add(customerId);
        }
      }

      foreach (var customerId in GetRepeatCustomers()) {
        AddInvoice(customerId, DataFactory.GetNextInvoice(), runnerDate);
      }

    }

    static void ProcessDayInPhase5(DateTime runnerDate) {
      RecreateContext();

      int customerCount = RandomNumber.Next(12, 55);
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

    static void ProcessDayInPhase6(DateTime runnerDate) {
      RecreateContext();

      int customerCount = RandomNumber.Next(8, 42);
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

    static void ProcessDayInPhase7(DateTime runnerDate) {
      RecreateContext();

      int customerCount = RandomNumber.Next(12, 65);
      for (int counter = 0; counter <= customerCount; counter++) {
        int customerId = AddCustomer(DataFactory.GetNextCustomer(), runnerDate);
        if (RandomNumber.Next(1, 100) > 75) {
          repeatCustomers.Add(customerId);
        }
      }

      foreach (var customerId in GetRepeatCustomers()) {
        AddInvoice(customerId, DataFactory.GetNextInvoice(), runnerDate);
      }

    }

    static void ProcessDayInPhase8(DateTime runnerDate) {
      RecreateContext();

      int customerCount = RandomNumber.Next(15, 72);
      if (runnerDate.Equals(new DateTime(2013, 11, 29))) {
        customerCount = 384;
      }
      if (runnerDate.Equals(new DateTime(2013, 12, 2))) {
        customerCount = 204;
      }

      if (runnerDate.Month.Equals(12)) {
        if (runnerDate.Day < 6) {
          customerCount += 32;
        }
        else if (runnerDate.Day < 12) {
          customerCount += 40;
        }
        else if (runnerDate.Day < 18) {
          customerCount += 48;
        }
        else if (runnerDate.Day < 24) {
          customerCount += 15;
        }
        else if (runnerDate.Day < 30) {
          customerCount -= 85;
        }
      }

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

    static void ProcessDayInPhase9(DateTime runnerDate) {
      RecreateContext();

      int customerCount = RandomNumber.Next(20, 68);
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

    static void ProcessDayInPhase10(DateTime runnerDate) {
      RecreateContext();

      int customerCount = RandomNumber.Next(20, 74);
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

    static void ProcessDayInPhase11(DateTime runnerDate) {
      RecreateContext();

      int customerCount = RandomNumber.Next(30, 88);
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

    static void ProcessDayInPhase12(DateTime runnerDate) {
      RecreateContext();

      int customerCount = RandomNumber.Next(30, 94);
      if (runnerDate.Equals(new DateTime(2014, 11, 29))) {
        customerCount = 248;
      }
      if (runnerDate.Equals(new DateTime(2014, 12, 2))) {
        customerCount = 298;
      }


      if (runnerDate.Month.Equals(12)) {
        if (runnerDate.Day < 6) {
          customerCount += 140;
        }
        else if (runnerDate.Day < 12) {
          customerCount += 165;
        }
        else if (runnerDate.Day < 18) {
          customerCount += 88;
        }
        else if (runnerDate.Day < 24) {
          customerCount += 10;
        }
        else if (runnerDate.Day < 30) {
          customerCount -= 150;
        }
      }


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

    static void ProcessDayInPhase13(DateTime runnerDate) {
      RecreateContext();

      int customerCount = RandomNumber.Next(20, 42);
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

    static void ProcessDayInPhase14(DateTime runnerDate) {
      RecreateContext();

      int customerCount = RandomNumber.Next(32, 60);
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

    static void ProcessDayInPhase15(DateTime runnerDate) {
      RecreateContext();

      int customerCount = RandomNumber.Next(45, 88);
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

    static void ProcessDayInPhase16(DateTime runnerDate) {
      RecreateContext();

      int customerCount = RandomNumber.Next(52, 90);
      if (runnerDate.Equals(new DateTime(2015, 11, 27))) {
        customerCount = 202;
      }
      if (runnerDate.Equals(new DateTime(2015, 11, 30))) {
        customerCount = 380;
      }


      if (runnerDate.Month.Equals(12)) {
        if (runnerDate.Day < 6) {
          customerCount += 140;
        }
        else if (runnerDate.Day < 12) {
          customerCount += 165;
        }
        else if (runnerDate.Day < 18) {
          customerCount += 88;
        }
        else if (runnerDate.Day < 24) {
          customerCount += 10;
        }
        else if (runnerDate.Day < 30) {
          customerCount -= 220;
        }
      }


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
        MaximumAge = productData.MaximumAge,
        ProductImage = productData.ProductImage       
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
         @"CREATE TABLE [dbo].[Invoices] ([InvoiceId] int IDENTITY(1,1) NOT NULL, [InvoiceDate] datetime  NOT NULL, [InvoiceAmount] decimal(9,2)  NOT NULL, [InvoiceType] nvarchar(max)  NOT NULL, [CustomerId] int  NOT NULL);",
         @"CREATE TABLE [dbo].[InvoiceDetails] ([Id] int IDENTITY(1,1) NOT NULL, [Quantity] int  NOT NULL, [SalesAmount] decimal(9,2)  NOT NULL, [InvoiceId] int  NOT NULL, [ProductId] int  NOT NULL );",
         @"CREATE TABLE [dbo].[Products] ([ProductId] int IDENTITY(1,1) NOT NULL,[ProductCode] nvarchar(max)  NOT NULL,[Title] nvarchar(max)  NOT NULL,[Description] nvarchar(max)  NULL,[ProductCategory] nvarchar(max)  NULL,[UnitCost] decimal(9,2)  NULL,[ListPrice] decimal(9,2)  NOT NULL,[Color] nvarchar(max)  NULL,[MinimumAge] int  NULL,[MaximumAge] int  NULL,[ProductImage] [image] NULL);"
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
         @"CREATE TABLE [dbo].[Products] ([ProductId] [int] NOT NULL IDENTITY, [ProductCode] [nvarchar](max), [Title] [nvarchar](max), [Description] [nvarchar](max), [ProductCategory] [nvarchar](max), [UnitCost] [decimal](18, 2), [ListPrice] [decimal](18, 2) NOT NULL, [Color] [nvarchar](max), [MinimumAge] [int], [MaximumAge] [int], [ProductImage] [image] NULL, CONSTRAINT [PK_dbo.Products] PRIMARY KEY ([ProductId]) )",
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
