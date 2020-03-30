using System;
using System.Collections.Generic;

namespace FindRideToWork.Core.Domain
{
    public class Route
    {
        public string RouteName { get; protected set; }
        public Guid RouteId { get; protected set; }
        public RoutePoint StartPoint { get; protected set; }
        public RoutePoint EndPoint { get; protected set; }
        public ICollection<RoutePoint> Points { get; protected set; }

        public Vehicle Vehicle { get; protected set; }

        public Route()
        {
            
        }

        // distance

        public Route(Guid routeId, string routeName, Vehicle vehicle, RoutePoint startPoint, RoutePoint endPoint)
        {
            RouteId = routeId == Guid.Empty? throw new Exception("Invalid routeId.") : routeId;
            SetRouteName(routeName);
            SetRouteVehicle(vehicle);
            StartPoint = startPoint;
            EndPoint = endPoint;
        }

        private void SetRouteVehicle(Vehicle vehicle)
        {
            // TO DO: validation;
            // UPDATE            
            Vehicle = vehicle;
        }

        public void SetRouteName(string routeName)
        {
            if (string.IsNullOrWhiteSpace(routeName))
            {
                throw new Exception("RouteName cannot be null.");
            }
            
            if (RouteName == routeName) return;
            RouteName = routeName;
        }

        public static Route Create(Guid routeId, string routeName, Vehicle vehicle, RoutePoint startPoint, RoutePoint endPoint)
            => new Route(routeId, routeName, vehicle, startPoint, endPoint);
    }
}