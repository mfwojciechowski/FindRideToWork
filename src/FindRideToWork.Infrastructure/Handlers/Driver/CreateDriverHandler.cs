using System.Threading.Tasks;
using FindRideToWork.Infrastructure.Commands;
using FindRideToWork.Infrastructure.Commands.Driver;
using FindRideToWork.Infrastructure.Services;

namespace FindRideToWork.Infrastructure.Handlers.Driver
{
    public class CreateDriverHandler : ICommandHandler<CreateDriver>
    {
        private readonly IDriverService _driverService;
        public CreateDriverHandler(IDriverService driverService)
        {
            _driverService = driverService;
        }
        public async Task HandleAsync(CreateDriver command)
        {
            await _driverService.CreateDriverAsync(command.UserId);
        }
    }
}