using System;

namespace FindRideToWork.Infrastructure.DTO.Route
{
    public class RoutePointDTO
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string Address { get; set; }
    }
}