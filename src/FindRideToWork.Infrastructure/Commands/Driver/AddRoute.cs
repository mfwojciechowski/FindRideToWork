using System;

namespace FindRideToWork.Infrastructure.Commands.Driver
{
    public class AddRoute : ICommand
    {
        public Guid UserId { get; set; }
        public string Name { get; set; }
        public string VehiclePlates { get; set; }
        public double StartLatitude { get; set; }
        public double StartLongitude { get; set; }
        public string StartAddress { get; set; }
        public double EndLatitude { get; set; }
        public double EndLongitude { get; set; }
        public string EndAddress { get; set; }
        
    }
}