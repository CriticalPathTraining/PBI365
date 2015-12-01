namespace WingtipDataGenerator.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FirstTime : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        CustomerId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Company = c.String(),
                        EmailAddress = c.String(),
                        WorkPhone = c.String(),
                        HomePhone = c.String(),
                        Address = c.String(),
                        City = c.String(),
                        State = c.String(),
                        ZipCode = c.String(),
                        Gender = c.String(),
                        BirthDate = c.DateTime(nullable: false),
                        FirstPurchaseDate = c.DateTime(),
                        LastPurchaseDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.CustomerId);
            
            CreateTable(
                "dbo.Invoices",
                c => new
                    {
                        InvoiceId = c.Int(nullable: false, identity: true),
                        InvoiceDate = c.DateTime(nullable: false),
                        InvoiceAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        InvoiceType = c.String(),
                        CustomerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.InvoiceId)
                .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: true)
                .Index(t => t.CustomerId);
            
            CreateTable(
                "dbo.InvoiceDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Quantity = c.Int(nullable: false),
                        SalesAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        InvoiceId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Invoices", t => t.InvoiceId, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.InvoiceId)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ProductId = c.Int(nullable: false, identity: true),
                        ProductCode = c.String(),
                        Title = c.String(),
                        Description = c.String(),
                        ProductCategory = c.String(),
                        UnitCost = c.Decimal(precision: 18, scale: 2),
                        ListPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Color = c.String(),
                        MinimumAge = c.Int(),
                        MaximumAge = c.Int(),
                    })
                .PrimaryKey(t => t.ProductId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.InvoiceDetails", "ProductId", "dbo.Products");
            DropForeignKey("dbo.InvoiceDetails", "InvoiceId", "dbo.Invoices");
            DropForeignKey("dbo.Invoices", "CustomerId", "dbo.Customers");
            DropIndex("dbo.InvoiceDetails", new[] { "ProductId" });
            DropIndex("dbo.InvoiceDetails", new[] { "InvoiceId" });
            DropIndex("dbo.Invoices", new[] { "CustomerId" });
            DropTable("dbo.Products");
            DropTable("dbo.InvoiceDetails");
            DropTable("dbo.Invoices");
            DropTable("dbo.Customers");
        }
    }
}
