using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FindRideToWork.Core.Domain;
using FindRideToWork.Core.Repositories;
using FindRideToWork.Infrastructure.DTO.Route;

namespace FindRideToWork.Infrastructure.Services
{
    public class RouteService : IRouteService
    {
        private readonly IDriverRepository _driverRepository;
        private readonly IUserRepository _userRepository;
        private readonly IRouteRepository _routeRepository;
        private readonly IMapper _mapper;
        public RouteService(IDriverRepository driverRepository, IUserRepository userRepository, IRouteRepository routeRepository, IMapper mapper)
        {
            _driverRepository = driverRepository;
            _userRepository = userRepository;
            _routeRepository = routeRepository;
            _mapper = mapper;
        }

        public async Task AddRouteAsync(Guid userId, Guid routeId, string name,string plates, double startLatitude, double startLongitude, string startAddress, double endLatitude, double endLongitude, string endAddress)
        {
            var driver = await _driverRepository.GetDriverAsync(userId);
            if(driver == null)
            {
                throw new Exception("Driver");
            }
            
            var vehicle = driver.Vehicles.SingleOrDefault(p => p.Plates == plates);
            if(vehicle == null)
            {
                throw new Exception("Vehicle");
            }
            var startPoint = new RoutePoint(startLatitude, startLongitude, startAddress);
            var endPoint = new RoutePoint(endLatitude, endLongitude, endAddress);

            driver.AddRoute(routeId, name, vehicle, startPoint, endPoint);

            await _driverRepository.UpdateDriverAsync(driver);
        }

        public async Task AddSingularRouteAsync(Guid userId, Guid routeId, Guid singularRouteId, DateTime startDate, DateTime endDate, int maxSeats)
        {
            var driver = await _driverRepository.GetDriverAsync(userId);
            var route = driver.Routes.SingleOrDefault(p=>p.RouteId == routeId);
            if(route == null)
            {
                throw new Exception("Route doesn't exist");
            }
            var singularRoute = new SingularRoute(singularRouteId, route, startDate, endDate, maxSeats);
            await _routeRepository.AddSingularRouteAsync(singularRoute);
        }
        

        public async Task<IEnumerable<SingularRouteDetailsDTO>> GetSingularRoutesByMapBoundaryCoordinatesAsync(double leftLatitude, 
                                                                                                    double rightLatitude, 
                                                                                                    double upLongitude, 
                                                                                                    double downLongitude)
        {
            var routes = await _routeRepository.GetSingularRoutesAsync();
            var singularRoutes = routes.Where(p=> p.Route.StartPoint.Latitude >= leftLatitude 
                                                    && p.Route.StartPoint.Latitude <= rightLatitude 
                                                    && p.Route.StartPoint.Longitude >= downLongitude 
                                                    && p.Route.StartPoint.Longitude <= upLongitude);

                                                    
            return _mapper.Map<IEnumerable<SingularRoute>,IEnumerable<SingularRouteDetailsDTO>>(singularRoutes);
        }

        private Tuple<double,double> GetBoundaryCoordinates(double latitude, double longitude, int distance)
        {
            if (double.IsNaN(latitude) || double.IsNaN(longitude) )
            {
                throw new ArgumentException("Argument latitude or longitude is not a number");
            }
/* 
            var d1 = Latitude * (Math.PI / 180.0);
            var num1 = Longitude * (Math.PI / 180.0);
            var d2 = other.Latitude * (Math.PI / 180.0);
            var num2 = other.Longitude * (Math.PI / 180.0) - num1;
            var d3 = Math.Pow(Math.Sin((d2 - d1) / 2.0), 2.0) +
                     Math.Cos(d1) * Math.Cos(d2) * Math.Pow(Math.Sin(num2 / 2.0), 2.0); */

            return new Tuple<double, double>(3,3); 
        
        }
    }
}