﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace SclBaseball
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Games",
                url: "games",
                defaults: new { controller = "Game", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Schedule",
                url: "schedule",
                defaults: new { controller = "Game", action = "Schedule", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Standings",
                url: "standings",
                defaults: new { controller = "Game", action = "Standings", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Postseason",
                url: "postseason",
                defaults: new { controller = "Game", action = "Postseason", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "signin-google",
                url: "signin-google",
                defaults: new { controller = "Account", action = "ExternalLoginCallback" }
                );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
