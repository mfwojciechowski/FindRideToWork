using System.Threading.Tasks;
using FindRideToWork.Infrastructure.Commands;
using Microsoft.AspNetCore.Mvc;

namespace FindRideToWork.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public abstract class ApiCustomController : ControllerBase
    {
        protected ICommandDispatcher CommandDispatcher;

        protected ApiCustomController(ICommandDispatcher commanddispatcher)
        {
            CommandDispatcher = commanddispatcher;
        }
    }
}