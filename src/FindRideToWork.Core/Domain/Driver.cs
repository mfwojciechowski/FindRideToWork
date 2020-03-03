using System;
using System.Collections.Generic;

namespace FindRideToWork.Core.Domain
{
    public class Driver
    {
        public Guid DriverId { get; protected set; }
        public Guid UserId { get; protected set; }
        public ICollection<Vehicle> Vehicles { get; protected set;}
        public ICollection<Route> Routes { get; protected set;}

        public ICollection<SingularRoute> SingularRoutes { get; protected set; }



    }
}