﻿using Danishevskii.Nitka.Web.DI;
using System.Web.Http;


namespace Danishevskii.Nitka.Web
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services


            var container = UnityRegistercs.CreateUnityContainer();
            config.DependencyResolver = new UnityResolver(container);

            // Web API routes
            config.MapHttpAttributeRoutes();


            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
           
        }
    }
}
