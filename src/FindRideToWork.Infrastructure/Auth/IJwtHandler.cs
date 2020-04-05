using System;

namespace FindRideToWork.Infrastructure.Auth
{
    public interface IJwtHandler
    {
        JsonWebToken CreateToken(Guid userId, string role);
    }
}