using System.Collections.Generic;
using FindRideToWork.Core.Domain;

namespace FindRideToWork.Infrastructure.DTO.Driver
{
    public class DriverDTO
    {
        public IEnumerable<VehicleDetailsDTO> Vehicles { get; set; }
    }
}