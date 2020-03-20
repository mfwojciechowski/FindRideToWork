using System.Collections.Generic;
using System.Threading.Tasks;
using FindRideToWork.Infrastructure.Commands;
using FindRideToWork.Infrastructure.Commands.User;
using FindRideToWork.Infrastructure.DTO.User;
using FindRideToWork.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace FindRideToWork.Api.Controllers
{
    public class UserController : ApiCustomController
    {        
        private readonly IUserService _userService;
        public UserController(ICommandDispatcher commandDispatcher, IUserService userService)
        : base(commandDispatcher)
        {
            _userService = userService;
        }
        [HttpPost("createuser")]
        public async Task CreateUser([FromBody]CreateUser command)
        {
            await CommandDispatcher.DispatchAsync(command);
        }

        [HttpGet("users")]
        public async Task<IEnumerable<UserDTO>> GetUsersAsync()
        {
            return  await _userService.GetUsersAsync();
        }

        [HttpGet("user/{email}")]
        public async Task<UserDTO> GetUserAsync(string email)
        {
            return await _userService.GetUserAsync(email);
        }

    }
}