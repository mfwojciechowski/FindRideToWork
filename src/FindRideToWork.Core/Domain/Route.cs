using System;
using System.Collections.Generic;

namespace FindRideToWork.Core.Domain
{
    public class Route
    {
        public Guid RouteId { get; protected set; }

        public RoutePoint StartPoint { get; protected set; }
        public RoutePoint EndPoint { get; protected set; }
        public ICollection<RoutePoint> Points { get; protected set; }



    }
}