using ImperialVip.DataAccess;
using ImperialVip.DataAccess.Entities;
using System;
using System.Data.Entity;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace ImperialVip.WebUI
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            Database.SetInitializer(new CreateDatabaseIfNotExists<ImperialDatabaseContext>());
        }

        //protected void Application_BeginRequest(Object sender, EventArgs e)
        //{
        //    string userIP = HttpContext.Current.Request.UserHostAddress;
        //    string userAgent = HttpContext.Current.Request.UserAgent;

        //    // Ziyaretçi bilgilerini veritabanına kaydedin.
        //    using (var db = new ImperialDatabaseContext())
        //    {
        //        var visit = new Visit()
        //        {
        //            IPAddress = userIP,
        //            UserAgent = userAgent,
        //            VisitDate = DateTime.Now
        //        };

        //        db.Visits.Add(visit);
        //        db.SaveChanges();
        //    }
        //}
    }
}
