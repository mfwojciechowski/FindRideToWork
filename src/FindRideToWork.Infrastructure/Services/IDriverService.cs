using System;
using System.Threading.Tasks;
using FindRideToWork.Core.Domain;
using FindRideToWork.Infrastructure.DTO.Driver;

namespace FindRideToWork.Infrastructure.Services
{
    public interface IDriverService
    {
        Task CreateDriverAsync(Guid userId);
        Task AddVehicle(Guid userId, string brand, int seats, int doors, string plates, string carModel);
        Task<DriverDTO> GetDriver(Guid userId);
    }
}