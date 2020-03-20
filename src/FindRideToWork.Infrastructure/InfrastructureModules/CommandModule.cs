using System.Reflection;
using Autofac;
using FindRideToWork.Infrastructure.Commands;

namespace FindRideToWork.Infrastructure.InfrastructureModules
{
    public class CommandModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {            
            builder.RegisterAssemblyTypes(typeof(CommandModule).GetTypeInfo().Assembly)
                .AsClosedTypesOf(typeof(ICommandHandler<>))
                .InstancePerLifetimeScope();

            builder.RegisterType<CommandDispatcher>()
                .As<ICommandDispatcher>()
                .InstancePerLifetimeScope();            
        }
    }
}