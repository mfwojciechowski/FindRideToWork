using System;

namespace FindRideToWork.Infrastructure.DTO.Route
{
    public class RouteDetailsDTO
    {
        public string RouteName { get;  set; }
        public Guid RouteId { get;  set; }
        public RoutePointDTO StartPoint { get;  set; }
        public RoutePointDTO EndPoint { get;  set; }
    }
}