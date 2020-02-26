using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Nest {
    public class RouteConfig {
        public static void RegisterRoutes(RouteCollection routes) {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                null,
                url: "",
                defaults: new { controller = "Index", action = "Index" }
            );

            routes.MapRoute(
                null,
                url: "Feed",
                defaults: new { controller = "Post", action = "Feed", category = (string) null, page = 1}
            );

            routes.MapRoute(
                null,
                url: "Feed/{page}",
                defaults: new { controller = "Post", action = "Feed", category = (string) null, page =  @"\d+" }
            );

            routes.MapRoute(
                null,
                url: "Feed/{category}/{page}",
                defaults: new { controller = "Post", action = "Feed", page = @"\d+" }
            );

            routes.MapRoute(
                null,
                url: "Admin/{action}/{id}",
                defaults: new { controller = "Admin", id = @"\d+" }
            );

            routes.MapRoute(
                null,
                url: "{controller}",
                defaults: new { action = "Index" }
            );

            routes.MapRoute(
                null,
                url: "{controller}/{action}"
            );
        }
    }
}
