using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FindRideToWork.Core.Domain;
using FindRideToWork.Core.Repositories;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using MongoDB.Driver.Core;

namespace FindRideToWork.Infrastructure.Repositories.MongoRepositories
{
    public class UserRepository : IUserRepository, IMongoRepository
    {
        private readonly IMongoDatabase _mongoDatabase;
        public UserRepository(IMongoDatabase mongoDatabase)
        {
            _mongoDatabase = mongoDatabase;
        }
        public async Task AddUserAsync(User user)
        {
            await Users.InsertOneAsync(user);
        }

        public async Task<User> GetUserAsync(string email)
        {
            return await Users.AsQueryable().FirstOrDefaultAsync(p=>p.Email == email);
        }

        public async Task<User> GetUserAsync(Guid userId)
        {
            return await Users.AsQueryable().FirstOrDefaultAsync(p=>p.UserId == userId);
        }

        public async Task<IEnumerable<User>> GetUsersAsync()
        {
            return await Users.AsQueryable().ToListAsync();
        }

        private IMongoCollection<User> Users => _mongoDatabase.GetCollection<User>("Users");
    }
}