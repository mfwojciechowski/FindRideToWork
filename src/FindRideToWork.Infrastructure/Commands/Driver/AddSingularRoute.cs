using System;

namespace FindRideToWork.Infrastructure.Commands.Driver
{
    public class AddSingularRoute : ICommand
    {
        public Guid UserId { get; set; }
        public Guid RouteId { get; set; }
        public int MaxSeats { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}