using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FindRideToWork.Infrastructure.Commands;
using FindRideToWork.Infrastructure.Commands.Driver;
using FindRideToWork.Infrastructure.DTO.Driver;
using FindRideToWork.Infrastructure.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FindRideToWork.Api.Controllers
{
    public class DriverController : ApiCustomController
    {
        private readonly IUserService _userService;
        private readonly IDriverService _driverService;
        public DriverController(ICommandDispatcher commandDispatcher, IUserService userService, IDriverService driverService)
        : base(commandDispatcher)
        {
            _userService = userService;
            _driverService = driverService;
        }

        [HttpPost("adddriver")]
        [Authorize]
        public async Task AddDriver([FromBody]AddDriver command)
        {
            await DispatchAsync(command);
        }

        [HttpPost("addvehicle")]
        [Authorize]
        public async Task AddVehicle([FromBody]AddVehicle command)
        {
            await DispatchAsync(command);
        }
        
        [HttpGet("getdriver/{userId}")]
        public async Task<IEnumerable<Guid>> GetDriver(Guid userId)
        {
            return await _driverService.GetDriverRoute(userId);
        }
    }
}