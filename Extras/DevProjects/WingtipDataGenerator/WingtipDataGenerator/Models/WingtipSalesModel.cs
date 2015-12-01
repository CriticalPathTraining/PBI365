using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WingtipDataGenerator.Models {

  public class Customer {
    [Key]
    public int CustomerId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Company { get; set; }
    public string EmailAddress { get; set; }
    public string WorkPhone { get; set; }
    public string HomePhone { get; set; }
    public string Address { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string ZipCode { get; set; }
    public string Gender { get; set; }
    public DateTime BirthDate { get; set; }
    public Nullable<DateTime> FirstPurchaseDate { get; set; }
    public Nullable<DateTime> LastPurchaseDate { get; set; }

    public virtual ICollection<Invoice> Invoices { get; set; }

    public Customer() {
      this.Invoices = new HashSet<Invoice>();
    }

  }

  public class Invoice {    
    [Key]
    public int InvoiceId { get; set; }
    public DateTime InvoiceDate { get; set; }
    public decimal InvoiceAmount { get; set; }
    public string InvoiceType { get; set; }
    public int CustomerId { get; set; }

    public virtual Customer Customer { get; set; }
    public virtual ICollection<InvoiceDetail> InvoiceDetails { get; set; }

    public Invoice() {
      this.InvoiceDetails = new HashSet<InvoiceDetail>();
    }

  }

  public class InvoiceDetail {
    [Key]
    public int Id { get; set; }
    public int Quantity { get; set; }
    public decimal SalesAmount { get; set; }
    public int InvoiceId { get; set; }
    public int ProductId { get; set; }

    public virtual Invoice Invoice { get; set; }
    public virtual Product Product { get; set; }
  }

  public class Product {
    [Key]
    public int ProductId { get; set; }
    public string ProductCode { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string ProductCategory { get; set; }
    public Nullable<decimal> UnitCost { get; set; }
    public decimal ListPrice { get; set; }
    public string Color { get; set; }
    public Nullable<int> MinimumAge { get; set; }
    public Nullable<int> MaximumAge { get; set; }

    public virtual ICollection<InvoiceDetail> InvoiceDetails { get; set; }
  }

}
