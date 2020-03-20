using System;
using System.Threading.Tasks;
using FindRideToWork.Core.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace FindRideToWork.Infrastructure.Services
{
    public class AccountService : IAccountService
    {
        private readonly IUserRepository _userRepository;
        public AccountService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        
        [HttpPost]
        public Task ChangePassword(Guid userId, string password, string newPassword)
        {
            throw new System.NotImplementedException();
        }
        
        [HttpPost]
        public Task ResetPassword(Guid userId)
        {
            throw new NotImplementedException();
        } 
    }
}