using System.Threading.Tasks;
using FindRideToWork.Infrastructure.Commands;
using FindRideToWork.Infrastructure.Commands.Driver;
using FindRideToWork.Infrastructure.Services;

namespace FindRideToWork.Infrastructure.Handlers.Driver
{
    public class AddVehicleHandler : ICommandHandler<AddVehicle>
    {
         private readonly IDriverService _driverService;
        public AddVehicleHandler(IDriverService driverService)
        {
            _driverService = driverService;
        }
        public async Task HandleAsync(AddVehicle command)
        {
            await _driverService.AddVehicleAsync(command.UserId, command.Brand, command.SeatsNumber, command.Doors, command.Plates, command.CarModel, command.ColorId);
        }
        
    }
}