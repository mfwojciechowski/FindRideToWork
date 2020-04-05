using System;

namespace FindRideToWork.Infrastructure.Commands.Passenger
{
    public class AddPassenger : ICommand
    {
        public Guid UserId { get; set; }
    }
}