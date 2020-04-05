using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using FindRideToWork.Core.Domain;
using FindRideToWork.Core.Repositories;
using FindRideToWork.Infrastructure.DTO.User;
using AutoMapper;
using FindRideToWork.Infrastructure.Auth;
using Microsoft.AspNetCore.Identity;

namespace FindRideToWork.Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IJwtHandler _jwtHandler;
        private readonly IPasswordHasher<User> _passwordHasher;
        public UserService(IUserRepository userRepository, IMapper mapper, IJwtHandler jwtHandler, IPasswordHasher<User> passwordHasher)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _jwtHandler = jwtHandler;
            _passwordHasher = passwordHasher;
        }

        public async Task SignUpAsync(Guid userId, string firstName, string lastName, string email, int roleId, string password, bool isVerified, int languageId)
        {
            byte[] saltPassword;
            byte[] hashPassword;

            var user = await _userRepository.GetUserAsync(email);

            if(user!=null)
            {
                throw new Exception("A User already exists!");
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

        public async Task<IdentityJsonToken> SignInAsync(string email, string password)
        {
            var user = await _userRepository.GetUserAsync(email);

            if (user == null) throw new Exception("Invalid credentials!");
            if(!IsPasswordCorrect(password, user.HashPassword, user.SaltPassword)) throw new Exception("Invalid credentials!");

            var jwt = _jwtHandler.CreateToken(user.UserId, user.Role.ToString());

            var refreshToken = _passwordHasher.HashPassword(user, "password");

            return new IdentityJsonToken
            {
                Expires = jwt.Expires,
                RefreshToken = refreshToken, 
                Token = jwt.Token
            };
        }

        public Task SignUpAsync(string email, string password)
        {
            throw new NotImplementedException();
        }
    }
}