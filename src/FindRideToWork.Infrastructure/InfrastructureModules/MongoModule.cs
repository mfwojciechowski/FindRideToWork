using System.Reflection;
using Autofac;
using FindRideToWork.Infrastructure.Repositories.MongoRepositories;
using FindRideToWork.Infrastructure.Settings;
using MongoDB.Driver;

namespace FindRideToWork.Infrastructure.InfrastructureModules
{
    public class MongoModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register((a, b) =>
            {
                var settings = a.Resolve<MongoSettings>();
                return new MongoClient(settings.ConnectionString);

            }).SingleInstance();

            builder.Register((a, b) =>
            {
                var client = a.Resolve<MongoClient>();
                var settings = a.Resolve<MongoSettings>();
                return client.GetDatabase(settings.Database);

            }).As<IMongoDatabase>();


            builder.RegisterAssemblyTypes(typeof(MongoModule).GetTypeInfo().Assembly)
                     .Where(p => p.IsAssignableTo<IMongoRepository>())
                     .AsImplementedInterfaces()
                     .InstancePerLifetimeScope();
        }
    }
}