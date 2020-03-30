using System.Collections.Generic;
using System.Threading.Tasks;
using FindRideToWork.Core.Domain;
using FindRideToWork.Core.Repositories;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using MongoDB.Driver.Core;

namespace FindRideToWork.Infrastructure.Repositories.MongoRepositories
{
    public class RouteRepository : IRouteRepository, IMongoRepository
    {
        private readonly IMongoDatabase _mongoDatabase;
        public RouteRepository(IMongoDatabase mongoDatabase)
        {
            _mongoDatabase = mongoDatabase;
        }

        public async Task AddSingularRouteAsync(SingularRoute singularRoute)
        {
            await SingularRoutes.InsertOneAsync(singularRoute);
        }

        public async Task<IEnumerable<SingularRoute>> GetSingularRoutesAsync()
        {
            return await SingularRoutes.AsQueryable().ToListAsync();
        }

        private IMongoCollection<SingularRoute> SingularRoutes => _mongoDatabase.GetCollection<SingularRoute>("SingularRoutes");
    }
}