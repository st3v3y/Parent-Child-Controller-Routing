﻿using System.Web.Mvc;
using System.Web.Routing;
using ControllerHiding.Routing;

namespace ControllerHiding
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            var defaultRoute = routes.MapRoute(
                "Page",
                "{*path}", //this catches everything
                new { controller = "Home", action = "Index", path = UrlParameter.Optional },
                new { path = new PagePathConstraint() }
            );
            defaultRoute.RouteHandler = new RenderRouteHandler();

            routes.MapRoute(
                name: "SubControllers",
                url: "{controller}/{action}/{Identifier}",
                defaults: new { controller = "Home", action = "Index", Identifier = UrlParameter.Optional }
            );
        }
    }
}
