using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace API_Vigilancia
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Configuración y servicios de API web

            // Rutas de API web
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            //config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new System.Net.Http.Headers.MediaTypeHeaderValue("text/html"));

            //config.Routes.MapHttpRoute(
            //    name: "DefaultApi",
            //    routeTemplate: "api/{controller}/{table}",
            //    defaults: new { table = RouteParameter.Optional }
            //);

            //config.Routes.MapHttpRoute(
            //    name: "M52",
            //    routeTemplate: "api/M52/{table}",
            //    defaults: new { table = RouteParameter.Optional }
            //);

            //config.Routes.MapHttpRoute(
            //    name: "ApiM52",
            //    routeTemplate: "api/M52/{table}",
            //    defaults: new { controller = "M52", table = RouteParameter.Optional }
            //);
        }
    }

    
}
