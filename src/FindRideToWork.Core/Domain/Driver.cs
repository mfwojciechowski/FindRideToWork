using System;
using System.Collections.Generic;
using System.Linq;

namespace FindRideToWork.Core.Domain
{
    public class Driver
    {        
        private ISet<Vehicle> _vehicles = new HashSet<Vehicle>();
        private ISet<Route> _route = new HashSet<Route>();
        private ISet<SingularRoute> _singularRoute = new HashSet<SingularRoute>();

        public Guid UserId{ get; set; }

        public ICollection<Vehicle> Vehicles
        {
            get { return _vehicles; }
            set { _vehicles = new HashSet<Vehicle>(value); }
        }
        public ICollection<Route> Routes
        {
            get { return _route; }
            set { _route = new HashSet<Route>(value); }
        }
        public ICollection<SingularRoute> SingularRoutes
        {
             get { return _singularRoute; }
             set { _singularRoute = new HashSet<SingularRoute>(value); }
        }

        public Driver(Guid userId)
        {            
            UserId = userId;
        }

        public void AddRoute(Guid routeId, string routeName, Vehicle vehicle, RoutePoint startPoint, RoutePoint endPoint)
        {
            if(GetRoute(routeName) != null)
            {
                throw new Exception("Route for driver exists");
            }
            _route.Add(Route.Create(routeId ,routeName, vehicle, startPoint, endPoint));
        }

        public void AddSingularRoute(SingularRoute singularRoute)
        {
            _singularRoute.Add(singularRoute);
        }

        public void AddVehicle(Vehicle vehicle)
        {
            if(GetVehicle(vehicle) != null)
            {
                throw new Exception("Vehicle is exists.");
            }
            _vehicles.Add(Vehicle.Create(vehicle.Brand, vehicle.SeatsNumber, vehicle.Doors, vehicle.Plates, vehicle.CarModel, vehicle.ColourId));
        }

        public Route GetRoute(string routeName)
            => _route.SingleOrDefault(p => p.RouteName == routeName);

         public SingularRoute GetSingularRoute(Guid singularRouteId)
            => _singularRoute.SingleOrDefault(p => p.SingularRouteId == singularRouteId); 

        public Vehicle GetVehicle(Vehicle vehicle)
            => _vehicles.SingleOrDefault(p => p.Plates == vehicle.Plates);

        // Driver is User
        // Driver can add general routes
        // Driver can remove general routes
        // Druiver can add Singular Route
        // Driver can remove Singular Route
        // Driver Can add/remove Vehicles
    }
}