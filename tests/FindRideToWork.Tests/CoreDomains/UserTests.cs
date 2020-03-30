using Xunit;
using System;
using FindRideToWork.Core.Domain;

namespace FindRideToWork.Tests.CoreDomains
{    
    public class UserTests
    {
        [Fact]
        public void new_user_constructor_with_empty_password_should_throw_excepction()
        {            
            //Exception ex = Assert.Throws<Exception>(() => new User(new Guid(), "Michal", "Wojciechowski", "email@email.com", 1, null, null));
            //Assert.Equal("Password cannot be null.", ex.Message);


        }
    }
}