using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using FindRideToWork.Core.Domain;
using FindRideToWork.Core.Repositories;
using FindRideToWork.Infrastructure.DTO.User;
using AutoMapper;

namespace FindRideToWork.Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task RegisterAsync(Guid userId, string firstName, string lastName, string email, int roleId, string password)
        {
            byte[] saltPassword;
            byte[] hashPassword;

            var user = await _userRepository.GetUserAsync(email);

            if(user!=null)
            {
                throw new Exception("User is exists!");
            }

            Utils.DataUtils.PasswordEncrypt(password, out saltPassword, out hashPassword);
            user = new User(userId, firstName, lastName, email, roleId, hashPassword, saltPassword);
            await _userRepository.AddUserAsync(user);
        }

        public async Task<IEnumerable<UserDTO>> GetUsersAsync()
        {
            var user = await _userRepository.GetUsersAsync();
            return _mapper.Map<IEnumerable<User>,IEnumerable<UserDTO>>(user);
        }

        public async Task<UserDTO> GetUserAsync(string email)
        {
            var user = await _userRepository.GetUserAsync(email);
            return _mapper.Map<User,UserDTO>(user);
        }
    }
}