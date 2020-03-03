using System;
using System.Collections.Generic;

namespace FindRideToWork.Core.Domain
{
    public class Passenger
    {
        public Guid PassengerId { get; protected set; }
        public Guid UserId { get; protected set; }
        public ICollection<PassengerRoutePoint> PickUpPoints { get; protected set;}
        
        // PASSENGER HAS A CAR AND OFFER ANOTHER ROUTES
    }
}