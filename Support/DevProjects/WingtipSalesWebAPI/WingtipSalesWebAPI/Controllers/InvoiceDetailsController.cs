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

  public class InvoiceDetailsController : ODataController {
    private WingtipSalesDB db = new WingtipSalesDB();

    // GET: odata/InvoiceDetails
    [EnableQuery]
    public IQueryable<InvoiceDetail> GetInvoiceDetails() {
      return db.InvoiceDetails;
    }

    // GET: odata/InvoiceDetails(5)
    [EnableQuery]
    public SingleResult<InvoiceDetail> GetInvoiceDetail([FromODataUri] int key) {
      return SingleResult.Create(db.InvoiceDetails.Where(invoiceDetail => invoiceDetail.Id == key));
    }

    // PUT: odata/InvoiceDetails(5)
    public IHttpActionResult Put([FromODataUri] int key, Delta<InvoiceDetail> patch) {
      Validate(patch.GetEntity());

      if (!ModelState.IsValid) {
        return BadRequest(ModelState);
      }

      InvoiceDetail invoiceDetail = db.InvoiceDetails.Find(key);
      if (invoiceDetail == null) {
        return NotFound();
      }

      patch.Put(invoiceDetail);

      try {
        db.SaveChanges();
      }
      catch (DbUpdateConcurrencyException) {
        if (!InvoiceDetailExists(key)) {
          return NotFound();
        }
        else {
          throw;
        }
      }

      return Updated(invoiceDetail);
    }

    // POST: odata/InvoiceDetails
    public IHttpActionResult Post(InvoiceDetail invoiceDetail) {
      if (!ModelState.IsValid) {
        return BadRequest(ModelState);
      }

      db.InvoiceDetails.Add(invoiceDetail);
      db.SaveChanges();

      return Created(invoiceDetail);
    }

    // PATCH: odata/InvoiceDetails(5)
    [AcceptVerbs("PATCH", "MERGE")]
    public IHttpActionResult Patch([FromODataUri] int key, Delta<InvoiceDetail> patch) {
      Validate(patch.GetEntity());

      if (!ModelState.IsValid) {
        return BadRequest(ModelState);
      }

      InvoiceDetail invoiceDetail = db.InvoiceDetails.Find(key);
      if (invoiceDetail == null) {
        return NotFound();
      }

      patch.Patch(invoiceDetail);

      try {
        db.SaveChanges();
      }
      catch (DbUpdateConcurrencyException) {
        if (!InvoiceDetailExists(key)) {
          return NotFound();
        }
        else {
          throw;
        }
      }

      return Updated(invoiceDetail);
    }

    // DELETE: odata/InvoiceDetails(5)
    public IHttpActionResult Delete([FromODataUri] int key) {
      InvoiceDetail invoiceDetail = db.InvoiceDetails.Find(key);
      if (invoiceDetail == null) {
        return NotFound();
      }

      db.InvoiceDetails.Remove(invoiceDetail);
      db.SaveChanges();

      return StatusCode(HttpStatusCode.NoContent);
    }

    // GET: odata/InvoiceDetails(5)/Invoice
    [EnableQuery]
    public SingleResult<Invoice> GetInvoice([FromODataUri] int key) {
      return SingleResult.Create(db.InvoiceDetails.Where(m => m.Id == key).Select(m => m.Invoice));
    }

    // GET: odata/InvoiceDetails(5)/Product
    [EnableQuery]
    public SingleResult<Product> GetProduct([FromODataUri] int key) {
      return SingleResult.Create(db.InvoiceDetails.Where(m => m.Id == key).Select(m => m.Product));
    }

    protected override void Dispose(bool disposing) {
      if (disposing) {
        db.Dispose();
      }
      base.Dispose(disposing);
    }

    private bool InvoiceDetailExists(int key) {
      return db.InvoiceDetails.Count(e => e.Id == key) > 0;
    }
  }
}
