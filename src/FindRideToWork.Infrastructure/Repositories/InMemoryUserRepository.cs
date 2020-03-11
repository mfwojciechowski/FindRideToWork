using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FindRideToWork.Core.Domain;
using FindRideToWork.Core.Repositories;

namespace FindRideToWork.Infrastructure.Repositories
{
    public class InMemoryUserRepository : IUserRepository
    {
        public ISet<User> _users = new HashSet<User>();

        public async Task AddAsync(User user)
        {            
            _users.Add(user);
			await Task.CompletedTask;
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