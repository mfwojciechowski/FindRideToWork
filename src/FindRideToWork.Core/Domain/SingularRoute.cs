using System;
using System.Collections.Generic;
using System.Linq;

namespace FindRideToWork.Core.Domain
{
    public class SingularRoute
    {
        private ISet<PassengerRoutePoint> _passengerRoutePoint = new HashSet<PassengerRoutePoint>();

        public Guid SingularRouteId { get; protected set; }

        public Route Route { get; protected set; }

        public ICollection<PassengerRoutePoint> PassengersRoutePoints
        { 
            get {return _passengerRoutePoint; }
            set { _passengerRoutePoint = new HashSet<PassengerRoutePoint>(value); }
        }

        public SingularRoute(Route route)
        {
            Route = route;
        }

        public void AddPassengerRoutePoint(RoutePoint routePoint, Passenger passenger)
        {
            //if exists --> throw        
            if (GetPassengerRoutePoint(passenger) != null)
            {
                throw new Exception("Route point is exists.");
            }

            _passengerRoutePoint.Add(PassengerRoutePoint.Create(routePoint, passenger));
        }

        public void RemovePassengerRoutePoint(Passenger passenger, PassengerRoutePoint passengerRoutePoint)
        {
            if(GetPassengerRoutePoint(passenger) == null)
            {
                throw new Exception("");
            }
            _passengerRoutePoint.Remove(passengerRoutePoint);
        }

        public PassengerRoutePoint GetPassengerRoutePoint(Passenger passenger)
            => _passengerRoutePoint.SingleOrDefault(p=>p.Passenger.PassengerId == passenger.PassengerId);

        
        //AddPassengerRoutePoint()
        //RemovePassengerRoutePoint()
        //GetPassengerRoutePoint
    }
}