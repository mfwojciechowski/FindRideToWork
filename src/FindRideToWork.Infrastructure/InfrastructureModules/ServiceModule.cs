using System.Reflection;
using Autofac;
using AutoMapper.Configuration;
using FindRideToWork.Infrastructure.Services;

namespace FindRideToWork.Infrastructure.InfrastructureModules
{
    public class ServiceModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var assembly = typeof(ServiceModule).GetTypeInfo().Assembly;
            builder.RegisterAssemblyTypes(assembly)
                    .Where(p => p.Name.EndsWith("Service"))
                    .AsImplementedInterfaces()
                    .InstancePerLifetimeScope();
        }
    }
}