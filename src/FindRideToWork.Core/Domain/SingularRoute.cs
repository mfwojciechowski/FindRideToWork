using System;
using System.Collections.Generic;

namespace FindRideToWork.Core.Domain
{
    public class SingularRoute
    {
        public Guid SingularRouteId { get; protected set; }

        public Route Route { get; protected set; }

        public ICollection<PassengerRoutePoint> PassengersRoutePoints { get; protected set; }


    }
}