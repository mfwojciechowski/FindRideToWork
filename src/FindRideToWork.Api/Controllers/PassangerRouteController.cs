using FindRideToWork.Infrastructure.Commands;

namespace FindRideToWork.Api.Controllers
{
    public class PassangerRouteController : ApiCustomController
    {
        public PassangerRouteController(ICommandDispatcher commandDispatcher)
        : base(commandDispatcher)
        {
        }
    }
}