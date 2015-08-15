using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Dabravata.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Categories",
                url: "Rooms/Category/{categoryId}",
                defaults: new { controller = "Rooms", action = "Index" },
                namespaces: new string[] { "Dabravata.Web.Controllers" }
            );

            routes.MapRoute(
                name: "RoomDetails",
                url: "Rooms/{id}",
                defaults: new { controller = "Rooms", action = "Details" },
                namespaces: new string[] { "Dabravata.Web.Controllers" }
            );

            routes.MapRoute(
                name: "Attractions",
                url: "Attractions/{id}",
                defaults: new { controller = "Attractions", action = "Index", id = UrlParameter.Optional },
                namespaces: new string[] { "Dabravata.Web.Controllers" }
            );

            routes.MapRoute(
                name: "Pages",
                url: "Pages/{id}",
                defaults: new { controller = "Pages", action = "Index"},
                namespaces: new string[] { "Dabravata.Web.Controllers" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new string[] { "Dabravata.Web.Controllers" }
            );
        }
    }
}
