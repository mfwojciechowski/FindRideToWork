using System.Threading.Tasks;
using System;
using FindRideToWork.Core.Repositories;

namespace FindRideToWork.Infrastructure.Services
{
    public class LoginService : ILoginService
    {
        private readonly IUserRepository _userRepository;
        public LoginService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<bool> SignIn(string email, string password)
        {
            var user = await _userRepository.GetUserAsync(email);
            if(user == null)
            {
                throw new Exception("User doesn't exist.");
            }
            return Utils.DataUtils.VerifyPasswordHash(password, user.HashPassword, user.SaltPassword);
        }
    }
}