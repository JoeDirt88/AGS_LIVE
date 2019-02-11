using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace AGS.ServerAPI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "AGsoft/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
