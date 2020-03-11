using System;
using System.Threading.Tasks;
using FindRideToWork.Core.Domain;
using FindRideToWork.Core.Repositories;

namespace FindRideToWork.Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;

        }

        public async Task RegisterAsync(Guid userId, string firstName, string lastName, string email, int roleId, string hashPassword, string saltPassword, string username)
        {
            var user = new User(userId, firstName, lastName, email, roleId, hashPassword, saltPassword, username);
            await _userRepository.AddAsync(user);
        }
    }
}