using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FindRideToWork.Core.Domain;
using FindRideToWork.Infrastructure.DTO.Route;

namespace FindRideToWork.Infrastructure.Services
{
    public interface IRouteService
    {
        Task AddRouteAsync(Guid userId, Guid routeId, string name, string vehiclePlates, double startLatitude, double startLongitude, string startAddress, double endLatitude, double endLongitude, string endAddress);
        Task AddSingularRouteAsync(Guid userId, Guid routeId, Guid singularRouteId, DateTime startDate, DateTime endDate, int maxSeats);
        Task<IEnumerable<SingularRouteDetailsDTO>> GetSingularRoutesByMapBoundaryCoordinatesAsync(double leftLatitude, double rightLatitude, double upLongitude, double downLongitude);
    }
}