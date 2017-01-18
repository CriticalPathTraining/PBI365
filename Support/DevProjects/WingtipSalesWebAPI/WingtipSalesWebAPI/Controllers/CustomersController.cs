using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using System.Web.Http.OData;
using System.Web.Http.OData.Routing;
using WingtipSalesWebAPI.Models;

namespace WingtipSalesWebAPI.Controllers {

  public class CustomersController : ODataController {
    private WingtipSalesDB db = new WingtipSalesDB();

    // GET: odata/Customers
    [EnableQuery]
    public IQueryable<Customer> GetCustomers() {
      return db.Customers;
    }

    // GET: odata/Customers(5)
    [EnableQuery]
    public SingleResult<Customer> GetCustomer([FromODataUri] int key) {
      return SingleResult.Create(db.Customers.Where(customer => customer.CustomerId == key));
    }

    // PUT: odata/Customers(5)
    public IHttpActionResult Put([FromODataUri] int key, Delta<Customer> patch) {
      Validate(patch.GetEntity());

      if (!ModelState.IsValid) {
        return BadRequest(ModelState);
      }

      Customer customer = db.Customers.Find(key);
      if (customer == null) {
        return NotFound();
      }

      patch.Put(customer);

      try {
        db.SaveChanges();
      }
      catch (DbUpdateConcurrencyException) {
        if (!CustomerExists(key)) {
          return NotFound();
        }
        else {
          throw;
        }
      }

      return Updated(customer);
    }

    // POST: odata/Customers
    public IHttpActionResult Post(Customer customer) {
      if (!ModelState.IsValid) {
        return BadRequest(ModelState);
      }

      db.Customers.Add(customer);
      db.SaveChanges();

      return Created(customer);
    }

    // PATCH: odata/Customers(5)
    [AcceptVerbs("PATCH", "MERGE")]
    public IHttpActionResult Patch([FromODataUri] int key, Delta<Customer> patch) {
      Validate(patch.GetEntity());

      if (!ModelState.IsValid) {
        return BadRequest(ModelState);
      }

      Customer customer = db.Customers.Find(key);
      if (customer == null) {
        return NotFound();
      }

      patch.Patch(customer);

      try {
        db.SaveChanges();
      }
      catch (DbUpdateConcurrencyException) {
        if (!CustomerExists(key)) {
          return NotFound();
        }
        else {
          throw;
        }
      }

      return Updated(customer);
    }

    // DELETE: odata/Customers(5)
    public IHttpActionResult Delete([FromODataUri] int key) {
      Customer customer = db.Customers.Find(key);
      if (customer == null) {
        return NotFound();
      }

      db.Customers.Remove(customer);
      db.SaveChanges();

      return StatusCode(HttpStatusCode.NoContent);
    }

    // GET: odata/Customers(5)/Invoices
    [EnableQuery]
    public IQueryable<Invoice> GetInvoices([FromODataUri] int key) {
      return db.Customers.Where(m => m.CustomerId == key).SelectMany(m => m.Invoices);
    }

    protected override void Dispose(bool disposing) {
      if (disposing) {
        db.Dispose();
      }
      base.Dispose(disposing);
    }

    private bool CustomerExists(int key) {
      return db.Customers.Count(e => e.CustomerId == key) > 0;
    }
  }
}
