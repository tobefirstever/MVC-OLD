using System.Web.Http;
using WebActivatorEx;
using JuegoOlimpico.Services.WebApi;
using Swashbuckle.Application;
using System;
using System.Reflection;
using System.IO;

[assembly: PreApplicationStartMethod(typeof(SwaggerConfig), "Register")]

namespace JuegoOlimpico.Services.WebApi
{
    public static class SwaggerConfig
    {
        public static void Register()
        {
            var thisAssembly = typeof(SwaggerConfig).Assembly;

            GlobalConfiguration.Configuration
                .EnableSwagger(c =>
                {
               
                    string url = "https://www.cajaarequipa.pe/";

                    c?.SingleApiVersion("v1", "API JuegoOlimpico")
                        ?.Description("API JuegoOlimpico")
                        ?.Contact(cc => cc?.Name("Jose castillo mandamiento")
                            ?.Url(url + "Contactanos"))
                        ?.License(lc => lc?.Name("Uso autorizado para las aplicaciones")
                            ?.Url(url + "Transparencia"));
                    c?.ApiKey("apiKey")
                        ?.Description("API Key Authentication")
                        ?.Name("Authorization")
                        ?.In("header");
               
                })
                ?.EnableSwaggerUi(c => { c?.InjectJavaScript(thisAssembly, "JuegoOlimpico.Services.WebApi.CustomContent.api-key-header-auth.js"); });
        }
    }
}
