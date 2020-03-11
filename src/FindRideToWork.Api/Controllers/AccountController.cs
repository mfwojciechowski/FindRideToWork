using System.Threading.Tasks;
using FindRideToWork.Infrastructure.Commands;
using FindRideToWork.Infrastructure.Commands.Users;
using Microsoft.AspNetCore.Mvc;

namespace FindRideToWork.Api.Controllers
{
    public class AccountController : ApiCustomController
    {
        public AccountController(ICommandDispatcher commandDispatcher)
        : base(commandDispatcher)
        {
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody]CreateUser command)
        {
            await CommandDispatcher.DispatchAsync(command);
            return Created($"users/{command.Email}", null);
        }

        [HttpGet("{id}")]

        public IActionResult GetValue(int id)
        {
            return Ok(3);
        }
    }
}