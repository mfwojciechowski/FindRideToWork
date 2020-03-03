using System;

namespace FindRideToWork.Core.Domain
{
    public class PassengerRoutePoint
    {
        public RoutePoint RoutePoint { get; protected set; }
        public Passenger Passenger { get; protected set; }
    }
}