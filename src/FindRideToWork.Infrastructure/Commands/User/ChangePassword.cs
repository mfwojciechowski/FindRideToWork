using System;

namespace FindRideToWork.Infrastructure.Commands.User
{
    public class ChangePassword : ICommand
    {
        public Guid UserId { get; }
        public string CurrentPassword { get; }
        public string NewPassword { get; }
    }
}