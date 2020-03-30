using Autofac;
using FindRideToWork.Infrastructure.Helpers.Extensions;
using FindRideToWork.Infrastructure.Settings;
using Microsoft.Extensions.Configuration;

namespace FindRideToWork.Infrastructure.InfrastructureModules
{
    public class SettingsModule : Autofac.Module
    {
        private readonly IConfiguration _configuration;
        
        public SettingsModule(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterInstance(_configuration.GetSettings<SqlSettings>())
                   .SingleInstance();
            builder.RegisterInstance(_configuration.GetSettings<MongoSettings>())
                   .SingleInstance();
            builder.RegisterInstance(_configuration.GetSettings<JwtSettings>())
                   .SingleInstance();
            builder.RegisterInstance(_configuration.GetSettings<SwaggerOptions>())
                   .SingleInstance();
        }
        
    }
}