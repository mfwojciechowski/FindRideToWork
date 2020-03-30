using System;

namespace FindRideToWork.Infrastructure.Commands.Driver
{
    public class AddDriver : ICommand
    {
        public Guid UserId { get; set; }
    }
}