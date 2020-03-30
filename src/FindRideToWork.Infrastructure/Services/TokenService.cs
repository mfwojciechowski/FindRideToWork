using System;
using System.Threading.Tasks;

namespace FindRideToWork.Infrastructure.Services
{
    public class TokenService : ITokenService
    {
        public Task CreateToken(Guid userId)
        {
            throw new NotImplementedException();
        }

        public Task DeactivateAsync(string token)
        {
            throw new System.NotImplementedException();
        }

        public Task DeactivateCurrentAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> IsActiveAsync(string token)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> IsCurrentActiveToken()
        {
            throw new System.NotImplementedException();
        }
    }
}