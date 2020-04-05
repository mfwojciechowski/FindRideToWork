using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FindRideToWork.Infrastructure.Commands;
using FindRideToWork.Infrastructure.Commands.Driver;
using FindRideToWork.Infrastructure.Commands.Passenger;
using FindRideToWork.Infrastructure.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FindRideToWork.Api.Controllers
{
    public class PassengerController : ApiCustomController
    {
        private readonly IUserService _userService;
        public PassengerController(ICommandDispatcher commandDispatcher, IUserService userService)
        : base(commandDispatcher)
        {
            _userService = userService;
        }

        [HttpPost("AddPassenger")]
        [Authorize]
        public async Task AddPassenger([FromBody]AddPassenger command)
        {
            await DispatchAsync(command);
        }        
    }
}