using System;

namespace FindRideToWork.Core.Domain
{
    public class PassengerRoutePoint
    {
        public RoutePoint RoutePoint { get; protected set; }
        public Passenger Passenger { get; protected set; }

        public PassengerRoutePoint(RoutePoint routePoint, Passenger passenger)
        {
            RoutePoint = routePoint;
            Passenger = passenger;
        }

        public static PassengerRoutePoint Create(RoutePoint routePoint, Passenger passenger)
            => new PassengerRoutePoint(routePoint, passenger);
    }
}