using System.Threading.Tasks;
using FindRideToWork.Infrastructure.Commands;
using FindRideToWork.Infrastructure.Commands.User;
using FindRideToWork.Infrastructure.Services;

namespace FindRideToWork.Infrastructure.Handlers.User
{
    public class ChangeUserPasswordHandler : ICommandHandler<ChangePassword>
    {
        private readonly IUserService _userService;
        public ChangeUserPasswordHandler(IUserService userService)
        {
            _userService =  userService;
        }
        public async Task HandleAsync(ChangePassword command)
        {
            await _userService.ChangePasswordAsync(command.UserId, command.CurrentPassword, command.NewPassword);
            //sendEmailWithInformation by Email Service
        }
    }
}