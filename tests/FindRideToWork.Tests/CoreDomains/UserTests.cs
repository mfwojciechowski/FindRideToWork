using Xunit;
using System;
using FindRideToWork.Core.Domain;

namespace FindRideToWork.Tests.CoreDomains
{
    public class UserTests
    {
        [Fact]
        public void TestName()
        {
        //Given
        var user = new User(Guid.NewGuid(), "Jan", "Kowalski", "Kowalski", 5, "str", "str", "str");
        
        user.Assert(true);
        //When
        
        //Then
        }
        
    }
}