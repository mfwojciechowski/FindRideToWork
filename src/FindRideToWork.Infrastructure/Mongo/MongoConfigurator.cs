using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Conventions;

namespace FindRideToWork.Infrastructure.Mongo
{
    public static class MongoConfigurator
    {
        private static bool _isInitialized;

        public static void Initialize()
        {
            if(_isInitialized)
            {
                return;
            }
            RegisterConventions();
            _isInitialized = true;
        }

        private static void RegisterConventions()
        {
            ConventionRegistry.Register("WheeloConventions", new WheeloConventions(), x => true);
        }

        private class WheeloConventions : IConventionPack
        {
            public IEnumerable<IConvention> Conventions => new List<IConvention>{
                new IgnoreExtraElementsConvention(true),
                new CamelCaseElementNameConvention(),
                new EnumRepresentationConvention(BsonType.String)                
            };
        }
    }
}