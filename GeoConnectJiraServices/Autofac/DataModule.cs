using Autofac;
using GeoConnect.Application.Interfaces;
using GeoConnect.Application.Providers;
using GeoConnectJiraServices.Interfaces;
using GeoConnectJiraServices.Services;

namespace GeoConnectJiraServices.Autofac
{
    public class DataModule:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ProjectService>().As<IProjectsService>();
            builder.RegisterType<UserService>().As<IUser>();
            builder.RegisterType<JiraApplicationService>().As<IJiraApplicationService>();
           

        }
    }
}