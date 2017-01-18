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

  public class InvoicesController : ODataController {
    private WingtipSalesDB db = new WingtipSalesDB();

    // GET: odata/Invoices
    [EnableQuery]
    public IQueryable<Invoice> GetInvoices() {
      return db.Invoices;
    }

    // GET: odata/Invoices(5)
    [EnableQuery]
    public SingleResult<Invoice> GetInvoice([FromODataUri] int key) {
      return SingleResult.Create(db.Invoices.Where(invoice => invoice.InvoiceId == key));
    }

    // PUT: odata/Invoices(5)
    public IHttpActionResult Put([FromODataUri] int key, Delta<Invoice> patch) {
      Validate(patch.GetEntity());

      if (!ModelState.IsValid) {
        return BadRequest(ModelState);
      }

      Invoice invoice = db.Invoices.Find(key);
      if (invoice == null) {
        return NotFound();
      }

      patch.Put(invoice);

      try {
        db.SaveChanges();
      }
      catch (DbUpdateConcurrencyException) {
        if (!InvoiceExists(key)) {
          return NotFound();
        }
        else {
          throw;
        }
      }

      return Updated(invoice);
    }

    // POST: odata/Invoices
    public IHttpActionResult Post(Invoice invoice) {
      if (!ModelState.IsValid) {
        return BadRequest(ModelState);
      }

      db.Invoices.Add(invoice);
      db.SaveChanges();

      return Created(invoice);
    }

    // PATCH: odata/Invoices(5)
    [AcceptVerbs("PATCH", "MERGE")]
    public IHttpActionResult Patch([FromODataUri] int key, Delta<Invoice> patch) {
      Validate(patch.GetEntity());

      if (!ModelState.IsValid) {
        return BadRequest(ModelState);
      }

      Invoice invoice = db.Invoices.Find(key);
      if (invoice == null) {
        return NotFound();
      }

      patch.Patch(invoice);

      try {
        db.SaveChanges();
      }
      catch (DbUpdateConcurrencyException) {
        if (!InvoiceExists(key)) {
          return NotFound();
        }
        else {
          throw;
        }
      }

      return Updated(invoice);
    }

    // DELETE: odata/Invoices(5)
    public IHttpActionResult Delete([FromODataUri] int key) {
      Invoice invoice = db.Invoices.Find(key);
      if (invoice == null) {
        return NotFound();
      }

      db.Invoices.Remove(invoice);
      db.SaveChanges();

      return StatusCode(HttpStatusCode.NoContent);
    }

    // GET: odata/Invoices(5)/Customer
    [EnableQuery]
    public SingleResult<Customer> GetCustomer([FromODataUri] int key) {
      return SingleResult.Create(db.Invoices.Where(m => m.InvoiceId == key).Select(m => m.Customer));
    }

    // GET: odata/Invoices(5)/InvoiceDetails
    [EnableQuery]
    public IQueryable<InvoiceDetail> GetInvoiceDetails([FromODataUri] int key) {
      return db.Invoices.Where(m => m.InvoiceId == key).SelectMany(m => m.InvoiceDetails);
    }

    protected override void Dispose(bool disposing) {
      if (disposing) {
        db.Dispose();
      }
      base.Dispose(disposing);
    }

    private bool InvoiceExists(int key) {
      return db.Invoices.Count(e => e.InvoiceId == key) > 0;
    }
  }
}
