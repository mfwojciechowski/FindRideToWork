using System;
using System.Threading.Tasks;
using FindRideToWork.Core.Repositories;

namespace FindRideToWork.Infrastructure.Services
{
    public interface IUserService
    {
        Task RegisterAsync(Guid userId, string firstName, string lastName, string email, int role, string hashPassword, string saltPassword, string username);

    }
}