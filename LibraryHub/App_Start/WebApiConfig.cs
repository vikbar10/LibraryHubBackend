using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Web.Http;
using System.Web.Http.Cors;
using LibraryHub.App_Start;

namespace LibraryHub
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Configuración y servicios de Web API
            // Habilitar CORS para todas las solicitudes
            var cors = new EnableCorsAttribute("*", "*", "*"); 
            config.EnableCors(cors);

            // Rutas de Web API
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            //Swagger
            var swaggerConfig = new Swashbuckle.Application.SwaggerDocsConfig();
            swaggerConfig.SingleApiVersion("v1", "LibraryHub API");
            swaggerConfig.RootUrl(req => req.RequestUri.GetLeftPart(UriPartial.Authority));
            SwaggerConfig.Register(config);

            // Configurar el backend para devolver JSON por defecto
            //config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/html"));

            
        }
    }
}
