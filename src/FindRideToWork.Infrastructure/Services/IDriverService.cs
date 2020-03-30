using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FindRideToWork.Core.Domain;
using FindRideToWork.Infrastructure.DTO.Driver;

namespace FindRideToWork.Infrastructure.Services
{
    public interface IDriverService
    {
        Task AddDriverAsync(Guid userId);

        Task AddVehicleAsync(Guid userId, string brand, int seats, int doors, string plates, string carModel, int colourId);
        Task<IEnumerable<Guid>> GetDriverRoute(Guid userId);
        Task<DriverDTO> GetDriverAsync(Guid userId);

    }
}