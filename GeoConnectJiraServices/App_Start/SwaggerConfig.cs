using System.Web.Http;
using WebActivatorEx;
using GeoConnectJiraServices;
using Swashbuckle.Application;

[assembly: PreApplicationStartMethod(typeof(SwaggerConfig), "Register")]

namespace GeoConnectJiraServices
{
    public class SwaggerConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.EnableSwagger(c =>
                {
                    c.SingleApiVersion("v1", "Jira Service");
                })
                .EnableSwaggerUi(c =>
                {
                });
        }
    }
}
