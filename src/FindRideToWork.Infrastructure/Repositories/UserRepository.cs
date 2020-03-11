using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FindRideToWork.Core.Domain;
using FindRideToWork.Core.Repositories;

namespace FindRideToWork.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        // DI context
        public Task AddAsync(User user)
        {
            throw new NotImplementedException();
        }

        public Task<User> GetAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<User> GetAsync(string email)
        {
            throw new NotImplementedException();
        }

        public Task RemoveAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task SaveAsync(User user)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(User user)
        {
            throw new NotImplementedException();
        }
    }
}