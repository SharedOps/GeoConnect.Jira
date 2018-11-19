using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using Autofac;
using GeoConnectJiraServices.Autofac;
using Autofac.Integration.WebApi;
using Owin;

namespace GeoConnectJiraServices
{
    public class Startup 
    {
        public void Configuration(IAppBuilder appBuilder)
        {
            HttpConfiguration httpConfiguration = new HttpConfiguration();
            ContainerBuilder builder = new ContainerBuilder();
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            builder.RegisterModule(new DataModule());
            IContainer container = builder.Build();
            httpConfiguration.DependencyResolver = new AutofacWebApiDependencyResolver(container);
            WebApiConfig.Register(httpConfiguration);
            appBuilder.UseWebApi(httpConfiguration);

            //Swagger configuration
            SwaggerConfig.Register(httpConfiguration);
        }
    }
}