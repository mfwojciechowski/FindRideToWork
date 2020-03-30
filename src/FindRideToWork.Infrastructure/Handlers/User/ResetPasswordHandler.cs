using System.Threading.Tasks;
using FindRideToWork.Infrastructure.Commands;
using FindRideToWork.Infrastructure.Commands.User;
using FindRideToWork.Infrastructure.Services;

namespace FindRideToWork.Infrastructure.Handlers.User
{
    public class ResetPasswordHandler : ICommandHandler<ResetPassword>
    {
        private readonly IUserService _userService;
        public ResetPasswordHandler(IUserService userService)
        {
            _userService = userService;
        }
        public async Task HandleAsync(ResetPassword command)
        {
            await Task.CompletedTask;
        }
    }
}