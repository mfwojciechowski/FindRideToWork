using System;
using System.Collections.Generic;

namespace FindRideToWork.Core.Domain
{
    public class Route
    {
        public string RouteName{ get; protected set; }
        public RoutePoint StartPoint { get; protected set; }
        public RoutePoint EndPoint { get; protected set; }
        // distance
        // duiration
        // start time
        public ICollection<RoutePoint> Points { get; protected set; }

        public Route(string routeName, RoutePoint startPoint, RoutePoint endPoint)
        {
            SetRouteName(routeName);
            StartPoint = startPoint;
            EndPoint = endPoint;
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

        public static Route Create(string routeName, RoutePoint startPoint, RoutePoint endPoint)
            => new Route(routeName, startPoint, endPoint);
    }
}