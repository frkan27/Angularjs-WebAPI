using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace ComboboxDoldurma
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "Api",
                routeTemplate: "api/{controller}",
                defaults: null
            );
            config.Routes.MapHttpRoute(
                name: "ApiById",
                routeTemplate: "api/{controller}/{id}",
                defaults:null
            );
            config.Routes.MapHttpRoute(
                name: "ApiByName",
                routeTemplate: "api/{controller}/{action}/{GameId}",
                defaults: new { action = RouteParameter.Optional }
            );
        }
    }
}
