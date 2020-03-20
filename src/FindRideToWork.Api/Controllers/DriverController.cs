using System;
using System.Threading.Tasks;
using FindRideToWork.Infrastructure.Commands;
using FindRideToWork.Infrastructure.Commands.Driver;
using FindRideToWork.Infrastructure.DTO.Driver;
using FindRideToWork.Infrastructure.Services;
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

        [HttpPost("createdriver")]
        public async Task CreateDriver([FromBody]CreateDriver command)
        {
            await CommandDispatcher.DispatchAsync(command);
        }

        [HttpPost("addvehicle")]
        public async Task AddVehicle([FromBody]AddVehicle command)
        {
            await CommandDispatcher.DispatchAsync(command);
        }
        [HttpGet("getdriver/{userId}")]
        public async Task<DriverDTO> GetDriver(Guid userId)
        {
            return await _driverService.GetDriver(userId);
        }
    }
}