using System;
using System.Threading.Tasks;
using FindRideToWork.Infrastructure.Commands;
using FindRideToWork.Infrastructure.Commands.Users;
using FindRideToWork.Infrastructure.Services;

namespace FindRideToWork.Infrastructure.Handlers.Users
{
    public class CreateUserHandler : ICommandHandler<CreateUser>
    {
        private readonly IUserService _userService;
        public CreateUserHandler(IUserService userService)
        {
            _userService = userService;
        }
        public async Task HandleAsync(CreateUser command)
        {

            // check if exists 
            // _encrypte password
            var hashPassword = "asd";
            var saltPassword = "asd";
            await _userService.RegisterAsync(new Guid(), command.FirstName, command.LastName,command.Email, command.RoleId, hashPassword, saltPassword, command.Username);
            // logic flow 
            // use services
            // scalable 
        }
    }
}