using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.OData.Builder;
using System.Web.Http.OData.Extensions;
using WingtipSalesWebAPI.Models;

namespace WingtipSalesWebAPI {
  public static class WebApiConfig {
    public static void Register(HttpConfiguration config) {
      // Web API configuration and services
      ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
      builder.EntitySet<InvoiceDetail>("InvoiceDetails");
      builder.EntitySet<Invoice>("Invoices");
      builder.EntitySet<Customer>("Customers");
      builder.EntitySet<Product>("Products");
      config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());


      // Web API routes
      config.MapHttpAttributeRoutes();

      config.Routes.MapHttpRoute(
          name: "DefaultApi",
          routeTemplate: "api/{controller}/{id}",
          defaults: new { id = RouteParameter.Optional }
      );
    }
  }
}
