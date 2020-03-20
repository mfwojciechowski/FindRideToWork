using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FindRideToWork.Core.Domain;

namespace FindRideToWork.Core.Repositories
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetUsersAsync();
        Task<User> GetUserAsync(string email);
        Task<User> GetUserAsync(Guid userId);
        Task AddUserAsync(User user);
    }
}