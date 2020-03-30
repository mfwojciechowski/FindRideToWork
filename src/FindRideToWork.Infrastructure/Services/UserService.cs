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

        public async Task RegisterAsync(Guid userId, string firstName, string lastName, string email, int roleId, string password, bool isVerified, int languageId)
        {
            byte[] saltPassword;
            byte[] hashPassword;

            var user = await _userRepository.GetUserAsync(email);

            if(user!=null)
            {
                throw new Exception("User doesn't exist!");
            }

            PasswordEncrypt(password, out saltPassword, out hashPassword);
            user = new User(userId, firstName, lastName, email, roleId, hashPassword, saltPassword, isVerified, languageId);
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

        public async Task ChangePasswordAsync(Guid userId, string password, string newPassword)
        {
            byte[] saltPassword;
            byte[] hashPassword;

            var user = await _userRepository.GetUserAsync(userId);
            if(user == null) return;
            if(!IsPasswordCorrect(password, user.SaltPassword, user.HashPassword)) throw new Exception("Old password is incorrect.");
            if(string.IsNullOrEmpty(newPassword)) throw new Exception("New Password is incorrect");

            PasswordEncrypt(newPassword, out saltPassword, out hashPassword);
            user.SetPassword(hashPassword, saltPassword);
        }

        private static void PasswordEncrypt(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        private static bool IsPasswordCorrect(string password, byte[] storedHash, byte[] storedSalt)
        {
            if (password == null) throw new ArgumentNullException("password");
            if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Value cannot be empty or whitespace only string.", "password");
            if (storedHash.Length != 64) throw new ArgumentException("Invalid length of password hash (64 bytes expected).", "passwordHash");
            if (storedSalt.Length != 128) throw new ArgumentException("Invalid length of password salt (128 bytes expected).", "passwordHash");

            using (var hmac = new System.Security.Cryptography.HMACSHA512(storedSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != storedHash[i]) return false;
                }
            }
            return true;
        }

        public async Task LoginAsync(string email, string password)
        {
            var user = await _userRepository.GetUserAsync(email);

            if (user == null) throw new Exception("Invalid credentials!");
            if(!IsPasswordCorrect(password, user.HashPassword, user.SaltPassword)) throw new Exception("Invalid credentials!");
            
            return;
        }
    }
}