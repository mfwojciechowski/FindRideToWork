using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FindRideToWork.Infrastructure.Auth;
using FindRideToWork.Infrastructure.Commands;
using FindRideToWork.Infrastructure.Commands.User;
using FindRideToWork.Infrastructure.DTO.User;
using FindRideToWork.Infrastructure.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FindRideToWork.Api.Controllers
{
    public class UserController : ApiCustomController
    {        
        private readonly IUserService _userService;
        private readonly IJwtHandler _jwtToken;
        public UserController(ICommandDispatcher commandDispatcher, IUserService userService, IJwtHandler jwtToken)
        : base(commandDispatcher)
        {
            _jwtToken = jwtToken;
            _userService = userService;
        }
        [HttpPost("createuser")]
        public async Task CreateUser([FromBody]CreateUser command)
        {
            await DispatchAsync(command);
        }

        [HttpGet("users")]
        public async Task<IEnumerable<UserDTO>> GetUsers()
        {
            return  await _userService.GetUsersAsync();
        }

        [HttpGet("user/{email}")]
        public async Task<UserDTO> GetUser(string email)
        {            
            return await _userService.GetUserAsync(email);   
        }

        [HttpPost("resetpassword")]
        public async Task ResetPassword([FromBody]ResetPassword command)
        {
            await DispatchAsync(command);
        }

        [HttpPost("changepassword")]
        public async Task ChangePassword([FromBody]ChangePassword command)
        {
            await DispatchAsync(command);
        }

        [HttpGet("token")]
        public IActionResult GetToken(string email)
        {
            var token = _jwtToken.CreateToken(Guid.NewGuid(), "user");
            return Ok(token);
        }
    }
}