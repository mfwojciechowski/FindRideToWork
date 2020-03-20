using System;

namespace FindRideToWork.Infrastructure.DTO.User
{
    public class UserDTO
    {
        public Guid UserId { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }

    }
}