using System;
using System.Collections.Generic;
using System.Linq;

namespace FindRideToWork.Core.Domain
{
    public class SingularRoute
    {        
        public Guid SingularRouteId { get; protected set; }
        public Route Route { get; protected set; }
        public int MaxSeats { get; protected set; }
        public DateTime StartDate { get; protected set; }
        public DateTime EndDate { get; protected set; }
        public bool xDel { get; protected set; }


        public ICollection<PassengerRoutePoint> PassengersRoutePoints
        { 
            get {return _passengerRoutePoint; }
            set { _passengerRoutePoint = new HashSet<PassengerRoutePoint>(value); }
        }

        private ISet<PassengerRoutePoint> _passengerRoutePoint = new HashSet<PassengerRoutePoint>();

        public SingularRoute()
        {
            
        }

        public SingularRoute(Guid singularRouteId, Route route, DateTime startDate, DateTime endDate, int maxSeats)
        {
            SingularRouteId = singularRouteId == Guid.Empty? throw new Exception("Invalid singularRouteId.") : singularRouteId;
            SetRoute(route);
            SetMaxSeats(maxSeats);
            SetDate(startDate, endDate);
        }

        private void SetRoute(Route route)
        {
            if(route == null)
            {
                throw new Exception("Route cannot be null");
            }
            Route = route;
        }

        private void SetDate(DateTime startDate, DateTime endDate)
        {
            if(startDate == null || endDate == null)
            {
                throw new Exception("Date cannot be null");
            }

            if(startDate >= endDate)
            {
                throw new Exception("Invalid date");
            }
            StartDate = startDate;
            EndDate = endDate;
        }

        public void SetMaxSeats(int maxSeats)
        {            
            if(Route.Vehicle.SeatsNumber < maxSeats)
            {
                throw new Exception("Invalid maxSeats");
            }
            if(MaxSeats == maxSeats) return;

            MaxSeats = maxSeats;
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

    }
}