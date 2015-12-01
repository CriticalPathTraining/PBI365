namespace WingtipDataGenerator.Models {
  using System;
  using System.Data.Entity;
  using System.Linq;

  public class WingtipSales : DbContext {
    public WingtipSales()
        : base("name=WingtipSales") {
    }

    public virtual DbSet<Customer> Customers { get; set; }
    public virtual DbSet<Invoice> Invoices { get; set; }
    public virtual DbSet<InvoiceDetail> InvoiceDetails { get; set; }
    public virtual DbSet<Product> Products { get; set; }
  }

}