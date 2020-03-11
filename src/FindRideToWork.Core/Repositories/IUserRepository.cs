using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FindRideToWork.Core.Domain;

namespace FindRideToWork.Core.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetAsync(Guid id);
        Task RemoveAsync (Guid id);
        Task UpdateAsync(User user);
        Task<User> GetAsync(string email);
        Task SaveAsync(User user);
        Task AddAsync(User user);
    }

    //IDriverRepository
    //IPassengerRepository
    
}