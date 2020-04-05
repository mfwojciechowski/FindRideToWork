using System;

namespace FindRideToWork.Infrastructure.Commands
{
    public class AuthenticatiedCommand : IAuthenticatiedCommand
    {
        public Guid UserId { get ; set; }
    }
}