using System;
using System.Collections.Generic;
using FindRideToWork.Core.Domain;

namespace FindRideToWork.Core.Repositories
{
    public interface IUserRepository
    {
        User Get(Guid id);
        IEnumerable<User> GetAll();
        void Remove (Guid id);
        void Update(User user);
        User Get(string email);
        void Save(User user);
    }

    //IDriverRepository
    //IPassengerRepository
    
}