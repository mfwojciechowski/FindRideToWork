using Autofac;
using FindRideToWork.Infrastructure.Commands;

namespace FindRideToWork.Infrastructure.InfrastructureModule
{
    public class InfrastructureModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            
            builder.RegisterAssemblyTypes(typeof(InfrastructureModule).Assembly)
                .AsClosedTypesOf(typeof(ICommandHandler<>))
                .InstancePerLifetimeScope();

            builder.RegisterType<CommandDispatcher>()
                .As<ICommandDispatcher>()
                .InstancePerLifetimeScope();
            
        }
    }
}