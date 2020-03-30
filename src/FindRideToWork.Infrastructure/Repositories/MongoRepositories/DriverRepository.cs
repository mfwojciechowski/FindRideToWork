using System;
using System.Threading.Tasks;
using FindRideToWork.Core.Domain;
using FindRideToWork.Core.Repositories;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using MongoDB.Driver.Core;

namespace FindRideToWork.Infrastructure.Repositories.MongoRepositories
{
    public class DriverRepository : IDriverRepository, IMongoRepository
    {
        private readonly IMongoDatabase _mongoDatabase;
        public DriverRepository(IMongoDatabase mongoDatabase)
        {
            _mongoDatabase = mongoDatabase;
        }
        public async Task AddDriverAsync(Driver driver)
        {
            await Drivers.InsertOneAsync(driver);
        }

        public Task CreateDriverRouteAsync(Route route)
        {
            throw new NotImplementedException();
        }

        public async Task<Driver> GetDriverAsync(Guid userId)
        {
            return await Drivers.AsQueryable().FirstOrDefaultAsync(x => x.UserId == userId);
        }

        public async Task UpdateDriverAsync(Driver driver)
        {
            await Drivers.ReplaceOneAsync(p=>p.UserId == driver.UserId ,driver);
        }

        private IMongoCollection<Driver> Drivers => _mongoDatabase.GetCollection<Driver>("Drivers");
    }
}