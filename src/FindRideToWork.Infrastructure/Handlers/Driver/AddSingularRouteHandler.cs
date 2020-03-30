using System;
using System.Threading.Tasks;
using FindRideToWork.Infrastructure.Commands;
using FindRideToWork.Infrastructure.Commands.Driver;
using FindRideToWork.Infrastructure.Services;

namespace FindRideToWork.Infrastructure.Handlers.Driver
{
    public class AddSingularRouteHandler : ICommandHandler<AddSingularRoute>
    {
        private readonly IRouteService _routeService;
        public AddSingularRouteHandler(IRouteService routeService)
        {
            _routeService = routeService;
        }
    
        public async Task HandleAsync(AddSingularRoute command)
        {
            await _routeService.AddSingularRouteAsync(command.UserId, command.RouteId, Guid.NewGuid(),  command.StartDate, command.EndDate, command.MaxSeats);
        }
    }
}