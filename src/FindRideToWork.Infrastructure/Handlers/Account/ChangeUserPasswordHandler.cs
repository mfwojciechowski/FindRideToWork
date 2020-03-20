using System.Threading.Tasks;
using FindRideToWork.Infrastructure.Commands;
using FindRideToWork.Infrastructure.Commands.Account;
using FindRideToWork.Infrastructure.Services;

namespace FindRideToWork.Infrastructure.Handlers.Account
{
    public class ChangeUserPasswordHandler : ICommandHandler<ChangePassword>
    {
        private readonly IAccountService _accountService;
        public ChangeUserPasswordHandler(IAccountService accountService)
        {
            _accountService =  accountService;
        }
        public async Task HandleAsync(ChangePassword command)
        {
            //sendEmailWithInformation
            await _accountService.ChangePassword(command.UserId, command.CurrentPassword, command.NewPassword);
        }
    }
}