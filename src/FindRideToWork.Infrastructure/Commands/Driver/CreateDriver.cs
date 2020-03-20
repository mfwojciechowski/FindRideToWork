using System;

namespace FindRideToWork.Infrastructure.Commands.Driver
{
    public class CreateDriver : ICommand
    {
        public Guid UserId { get; set; }
    }
}