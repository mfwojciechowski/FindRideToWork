using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FindRideToWork.Core.Repositories;
using FindRideToWork.Infrastructure.DTO.User;

namespace FindRideToWork.Infrastructure.Services
{
    public interface IUserService
    {
        Task RegisterAsync(Guid userId, string firstName, string lastName, string email, int role, string password);
        Task<IEnumerable<UserDTO>> GetUsersAsync();
        Task<UserDTO> GetUserAsync(string email);
    }
}