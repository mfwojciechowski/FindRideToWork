using System;
using System.Threading.Tasks;

namespace FindRideToWork.Infrastructure.Services
{
    public interface ITokenService
    {
        Task<bool> IsCurrentActiveToken();
        Task DeactivateCurrentAsync();
        Task<bool> IsActiveAsync(string token);
        Task DeactivateAsync(string token);
        Task CreateToken(Guid userId);
    }
}