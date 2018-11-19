using System.Web.Http;
using WebActivatorEx;
using GeoConnect.Jira.TopShelfService;
using Swashbuckle.Application;

[assembly: PreApplicationStartMethod(typeof(SwaggerConfig), "Register")]

namespace GeoConnect.Jira.TopShelfService
{
    public class SwaggerConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.EnableSwagger(c =>
                {
                    c.SingleApiVersion("v1", "RetroNotesService");
                })
                .EnableSwaggerUi(c =>
                {
                });
        }

    }
}
