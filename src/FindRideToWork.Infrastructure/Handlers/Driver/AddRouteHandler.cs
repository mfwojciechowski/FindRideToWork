using System;
using System.Threading.Tasks;
using FindRideToWork.Infrastructure.Commands;
using FindRideToWork.Infrastructure.Commands.Driver;
using FindRideToWork.Infrastructure.Services;

namespace FindRideToWork.Infrastructure.Handlers.Driver
{
    public class AddRouteHandler : ICommandHandler<AddRoute>
    {
        private readonly IRouteService _routeService;
        public AddRouteHandler(IRouteService routeService)
        {
            _routeService = routeService;
        }

        public async Task HandleAsync(AddRoute command)
        {
            await _routeService.AddRouteAsync(command.UserId, Guid.NewGuid(), command.Name, command.VehiclePlates, command.StartLatitude, command.StartLongitude, command.StartAddress, command.EndLatitude, command.EndLongitude, command.EndAddress);
        }
    }
}