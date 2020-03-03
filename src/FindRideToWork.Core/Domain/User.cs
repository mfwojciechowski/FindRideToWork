using System;
using FindRideToWork.Core.Base;

namespace FindRideToWork.Core.Domain
{
    public class User
    {
        public Guid UserId { get; protected set; }
        public string FirstName { get; protected set; }
        public string LastName { get; protected set; }
        public string Email { get; protected set; }
        public int Role { get; protected set; }
        public string HashPassword { get; protected set; }
        public string SaltPassword { get; protected set; }
        public string Username { get; protected set; }
        public DateTime CreatedAt { get; protected set; }
        public DateTime UpdatedAt { get; protected set; }
        public string FullName { get { return $"{FirstName} {LastName}"; } }

        public User(Guid userId, string firstName, string lastName, string email, int role, string hashPassword, string saltPassword, string username)
        {
            UserId = userId;
            SetFirstName(firstName);
            SetLastName(firstName);
            SetEmail(email);
            SetRole(role);
            SetUsername(username);
            SetPassword(hashPassword, saltPassword);
        }

        private void SetPassword(string hashPassword, string saltPassword)
        {
            if (HashPassword == hashPassword || SaltPassword == saltPassword)
            {
                return;
            }

            HashPassword = hashPassword;
            SaltPassword = saltPassword;
            UpdatedAt = DateTime.UtcNow;
        }

        public void SetUsername(string username)
        {
            if (!Helpers.usernameRegex.IsMatch(username))
            {
                throw new Exception("Username is invalid");
            }

            Username = username.ToLower();
        }

        private void SetRole(int role)
        {
            if (!Enum.IsDefined(typeof(Roles), role))
            {
                throw new Exception("Invalid role type");
            }

            Role = role;
            UpdatedAt = DateTime.UtcNow;
        }

        private void SetEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                throw new Exception("Email cannot be empty");
            }

            if (Email == email)
            {
                return;
            }

            Email = email.ToLower();
            UpdatedAt = DateTime.UtcNow;
        }

        private void SetFirstName(string firstName)
        {
            if (string.IsNullOrEmpty(LastName))
            {
                throw new Exception("Firstname cannot be empty");
            }

            FirstName = firstName;
            UpdatedAt = DateTime.UtcNow;
        }

        private void SetLastName(string lastname)
        {
            if (string.IsNullOrWhiteSpace(lastname))
            {
                throw new Exception("Lastname name cannot be empty");
            }

            LastName = lastname;
            UpdatedAt = DateTime.UtcNow;
        }

        enum Roles : int
        {
            USER,
            ADMIN
        }
    }
}