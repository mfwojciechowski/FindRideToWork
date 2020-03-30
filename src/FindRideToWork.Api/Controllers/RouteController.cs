using System.Collections.Generic;
using System.Threading.Tasks;
using FindRideToWork.Infrastructure.Commands;
using FindRideToWork.Infrastructure.Commands.Driver;
using FindRideToWork.Infrastructure.DTO.Route;
using FindRideToWork.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace FindRideToWork.Api.Controllers
{
    public class RouteController : ApiCustomController
    {
        private readonly IUserService _userService;
        private readonly IRouteService _routeService;
        private readonly IDriverService _driverService;
        
        public RouteController(ICommandDispatcher commandDispatcher, IUserService userService, IRouteService routeService, IDriverService driverService)
        : base(commandDispatcher)
        {
            _userService = userService;
            _routeService = routeService;
            _driverService = driverService;
        }
        
        [HttpPost("addroute")]
        public async Task AddRoute([FromBody]AddRoute command)
        {
            await CommandDispatcher.DispatchAsync(command);
        }

        [HttpPost("addsingularroute")]
        public async Task AddSingularRoute([FromBody] AddSingularRoute command)
        {
            await CommandDispatcher.DispatchAsync(command);
        }

        [HttpGet("getsingularoute/{leftLatitude},{rightLatitude},{upLongitude},{downLongitude}")]
        public async Task<IEnumerable<SingularRouteDetailsDTO>> Get(double leftLatitude, double rightLatitude, double upLongitude, double downLongitude)
        {
            return await _routeService.GetSingularRoutesByMapBoundaryCoordinatesAsync(leftLatitude, rightLatitude, upLongitude, downLongitude);
        }
    }
}