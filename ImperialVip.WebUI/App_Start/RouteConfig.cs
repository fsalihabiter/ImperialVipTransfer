using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ImperialVip.WebUI
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            // Root URL için ("/") HomeController'ın Index action'ı çalışsın
            routes.MapRoute(
                name: "Root",
                url: "",
                defaults: new { controller = "Home", action = "Index" }
            );

            // AnasayfaController için route (tr)
            routes.MapRoute(
                name: "Anasayfa",
                url: "tr/{action}/{id}",
                defaults: new { controller = "Anasayfa", action = "Anasayfa", id = UrlParameter.Optional }
            );

            // AdminController için route (Admin aynı kalıyor)
            routes.MapRoute(
                name: "Admin",
                url: "Admin/{action}/{id}",
                defaults: new { controller = "Admin", action = "RezervasyonIslemleri", id = UrlParameter.Optional }
            );

            // HomeDeController için route (de)
            routes.MapRoute(
                name: "HomeDe",
                url: "de/{action}/{id}",
                defaults: new { controller = "HomeDe", action = "Index", id = UrlParameter.Optional }
            );

            // HomeRuController için route (ru)
            routes.MapRoute(
                name: "HomeRu",
                url: "ru/{action}/{id}",
                defaults: new { controller = "HomeRu", action = "Index", id = UrlParameter.Optional }
            );

            // Geçersiz URL'ler için yönlendirme
            routes.MapRoute(
                name: "InvalidUrl",
                url: "{*url}",
                defaults: new { controller = "Home", action = "Index" }
            );

            // HomeController için default route
            routes.MapRoute(
                name: "Default",
                url: "{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
