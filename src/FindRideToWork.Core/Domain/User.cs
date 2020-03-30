using System;
using System.Collections.Generic;
using System.Linq;
using FindRideToWork.Core.Base;
using FindRideToWork.Core.Entities;

namespace FindRideToWork.Core.Domain
{
    public class User
    {
        public Guid UserId { get; protected set; }
        public string FirstName { get; protected set; }
        public string LastName { get; protected set; }
        public string Email { get; protected set; }
        public int Role { get; protected set; }
        public byte[] HashPassword { get; protected set; }
        public byte[] SaltPassword { get; protected set; }
        public DateTime CreatedAt { get; protected set; }
        public DateTime UpdatedAt { get; protected set; }
        public int LanguageId { get; protected set; }
        public bool IsVerified { get; protected set; }
        public string FullName { get { return $"{FirstName} {LastName}"; } }

        public ICollection<Friends> Friends
        {
            get { return _friends; }
            set { _friends = new HashSet<Friends>(value); }
        }
        private ISet<Friends> _friends = new HashSet<Friends>();

        public User()
        {            
        }

        public User(Guid userId, string firstName, string lastName, string email, int role, byte[] hashPassword, byte[] saltPassword, bool isVerified, int languageId)
        {
            UserId = userId == Guid.Empty? throw new Exception("Invalid UserId.") : userId;
            SetFirstName(firstName);
            SetLastName(firstName);
            SetEmail(email);
            SetRole(role);
            SetPassword(hashPassword, saltPassword);
            SetIsVerified(isVerified);
            SetLanguage(languageId);
        }

        public void AddFriend(Friends friend)
        {
            if(friend == null)
            {
                throw new Exception("Friend cannot be null!");
            }
            _friends.Add(friend);
        }

        private void SetIsVerified(bool isVerified)
        {
            if(isVerified == IsVerified) return;

            IsVerified = isVerified;
            UpdatedAt = DateTime.Now;
        }

        private void SetLanguage(int languageId)
        {
            if(languageId == LanguageId) return;

            LanguageId = languageId;
            UpdatedAt = DateTime.Now;
        }

        public void SetPassword(byte[] hashPassword, byte[] saltPassword)
        {
            if(hashPassword == null || saltPassword == null)
            {
                throw new Exception("Password cannot be null.");
            }

            if (HashPassword == hashPassword || SaltPassword == saltPassword) return;

            HashPassword = hashPassword;
            SaltPassword = saltPassword;
            UpdatedAt = DateTime.UtcNow;
        }

        private void SetRole(int role)
        {
            if (!Enum.IsDefined(typeof(Roles), role))
            {
                throw new Exception("Invalid role type.");
            }

            if(role == Role) return;

            Role = role;
            UpdatedAt = DateTime.UtcNow;
        }

        private void SetEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                throw new Exception("Email cannot be empty.");
            }

            if(!Helpers.emailRegex.IsMatch(email))
            {
                throw new Exception("Email is invalid.");
            }

            if (Email == email) return;

            Email = email.ToLower();
            UpdatedAt = DateTime.UtcNow;
        }

        private void SetFirstName(string firstName)
        {
            if (string.IsNullOrWhiteSpace(firstName))
            {
                throw new Exception("Firstname cannot be empty.");
            }

            if (firstName == FirstName) return;
            
            FirstName = firstName;
            UpdatedAt = DateTime.UtcNow;
        }

        private void SetLastName(string lastname)
        {
            if (string.IsNullOrWhiteSpace(lastname))
            {
                throw new Exception("Lastname name cannot be empty.");
            }

            if (lastname == LastName) return;

            LastName = lastname;
            UpdatedAt = DateTime.UtcNow;
        }

        enum Roles : int
        {
            USER =1,
            ADMIN
        }

        enum Lanugages : int
        {
            Polish = 1,
            English
        }
    }
}