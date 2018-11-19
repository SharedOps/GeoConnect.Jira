using System.Web.Http;
using WebActivatorEx;
using GeoConnectWinService;
using Swashbuckle.Application;

[assembly: PreApplicationStartMethod(typeof(SwaggerConfig), "Register")]

namespace GeoConnectWinService
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
