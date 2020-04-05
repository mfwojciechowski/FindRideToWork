using System;
using System.Threading.Tasks;
using FindRideToWork.Infrastructure.Commands;
using Microsoft.AspNetCore.Mvc;

namespace FindRideToWork.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public abstract class ApiCustomController : ControllerBase
    {
        private readonly ICommandDispatcher _commandDispatcher;
        private Guid UserId => User?.Identity?.IsAuthenticated == true ? Guid.Parse(User.Identity.Name) : Guid.NewGuid();

        protected ApiCustomController(ICommandDispatcher commanddispatcher)
        {
            _commandDispatcher = commanddispatcher;
        }

        protected async Task DispatchAsync<T>(T command) where T : ICommand
        {
            if(command is IAuthenticatiedCommand authCommand)
            {
                authCommand.UserId = UserId;
            }
            await _commandDispatcher.DispatchAsync(command);
        }
    }
}