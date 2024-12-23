using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Swashbuckle.Application;

namespace LibraryHub.App_Start
{
    public class SwaggerConfig
    {
        public static void Register(System.Web.Http.HttpConfiguration config)
        {
            config.EnableSwagger(x =>
            {
                x.SingleApiVersion("v1", "LibraryHub API")
                .Description("API de gestion de libros y autores");
            })
            .EnableSwaggerUi();
        }
    }
}