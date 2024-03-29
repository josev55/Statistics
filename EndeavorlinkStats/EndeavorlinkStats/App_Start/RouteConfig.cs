﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace EndeavorlinkStats
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Login", action = "Index", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "GetStatsPage",
                url: "{controller}/{action}/{month}/{year}/{oper}",
                defaults: new { controller = "stats", action = "getOperatorStatPage", month = UrlParameter.Optional, year = UrlParameter.Optional });
        }
    }
}