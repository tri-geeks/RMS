using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace TG.RMSCLIENT.WEB
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                      "Admin",
                      "Account",
                      new { Controller = "Account", action = "Index" });
            //routes.MapRoute(
            //          "AdminPanel",
            //          "AdminPanel",
            //          new { Controller = "DashBoard", action = "Index" });

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}

//public static void RegisterRoutes(RouteCollection routes)
//        {
//            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

//            routes.MapRoute(
//                       "CSRL",
//                       "Home",
//                       new { Controller = "Home", action = "Index" });

//            routes.MapRoute(
//                      "LogOut",
//                      "LogIn",
//                      new { Controller = "Account", action = "Login" });

//            routes.MapRoute(
//                name: "Default",
//                url: "{controller}/{action}/{id}",
//                defaults: new { controller = "Account", action = "Login", id = UrlParameter.Optional }
//            );
//        }