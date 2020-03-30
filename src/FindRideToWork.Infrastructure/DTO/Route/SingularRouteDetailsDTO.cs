using System;

namespace FindRideToWork.Infrastructure.DTO.Route
{
    public class SingularRouteDetailsDTO
    {
        public Guid SingularRouteId { get; set; }
        public RouteDetailsDTO Route { get; set; }
        public int MaxSeats { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}