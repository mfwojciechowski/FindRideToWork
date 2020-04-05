using System;

namespace FindRideToWork.Infrastructure.Commands
{
    public interface IAuthenticatiedCommand : ICommand
    {
         Guid UserId { get; set; }
    }
}