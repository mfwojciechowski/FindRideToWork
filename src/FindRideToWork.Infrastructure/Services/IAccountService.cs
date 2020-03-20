using System;
using System.Threading.Tasks;

namespace FindRideToWork.Infrastructure.Services
{
    public interface IAccountService
    {
        Task ChangePassword(Guid userId, string password, string newPassword);
        Task ResetPassword(Guid userId);
    }
}