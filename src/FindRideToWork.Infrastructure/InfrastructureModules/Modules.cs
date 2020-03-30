using System.Reflection;
using Autofac;
using Microsoft.Extensions.Configuration;

namespace FindRideToWork.Infrastructure.InfrastructureModules
{
    public class Modules : Autofac.Module
    {
        private readonly IConfiguration _configuration;

        public Modules(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterModule<CommandModule>();
            builder.RegisterModule<MongoModule>();
            builder.RegisterModule<ServiceModule>();
            builder.RegisterModule(new SettingsModule(_configuration));
        }
    }
}