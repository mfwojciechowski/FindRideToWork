using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FindRideToWork.Core.Domain;
using FindRideToWork.Core.Repositories;

namespace FindRideToWork.Infrastructure.Repositories.InMemoryReposiories
{
    public class InMemoryUserRepository : IUserRepository
    {
        public static readonly ISet<User> _users = new HashSet<User>();

        public Task AddAsync(User user)
        {
            throw new NotImplementedException();
        }

        public async Task AddUserAsync(User user)
        {
            _users.Add(user);
			await Task.CompletedTask;
        }

        public async Task<User> GetAsync(string email)
        {
            return await Task.FromResult(_users.SingleOrDefault(p => p.Email == email));
        }

        public async Task<User> GetUserAsync(string email)
        {
            var user = _users.SingleOrDefault(p => p.Email.Equals(email, StringComparison.CurrentCultureIgnoreCase));
            return await Task.FromResult(user);
        }

        public async Task<User> GetUserAsync(Guid userId)
        {
            return await Task.FromResult(_users.SingleOrDefault(p => p.UserId == userId));
        }

        public async Task<IEnumerable<User>> GetUsersAsync()
        {
            return await Task.FromResult(_users);
        }
    }
}