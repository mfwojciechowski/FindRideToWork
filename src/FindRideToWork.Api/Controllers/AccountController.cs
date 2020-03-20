using System.Collections.Generic;
using System.Threading.Tasks;
using FindRideToWork.Infrastructure.Commands;
using FindRideToWork.Infrastructure.Commands.Account;
using FindRideToWork.Infrastructure.Commands.User;
using FindRideToWork.Infrastructure.DTO.User;
using FindRideToWork.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace FindRideToWork.Api.Controllers
{
    public class AccountController : ApiCustomController
    {
        private readonly IUserService _userService;
        public AccountController(ICommandDispatcher commandDispatcher, IUserService userService)
        : base(commandDispatcher)
        {
            _userService = userService;
        }
        [HttpPost("resetpassword")]
        public async Task ResetPassword([FromBody]ResetPassword command)
        {
            await CommandDispatcher.DispatchAsync(command);
        }

        [HttpPost("changepassword")]
        public async Task ChangePassword([FromBody]ChangePassword command)
        {
            await CommandDispatcher.DispatchAsync(command);
        }
    }
}