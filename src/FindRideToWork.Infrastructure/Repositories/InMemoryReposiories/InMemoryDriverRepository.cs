using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FindRideToWork.Core.Domain;
using FindRideToWork.Core.Repositories;

namespace FindRideToWork.Infrastructure.Repositories.InMemoryReposiories
{
    public class InMemoryDriverRepository : IDriverRepository
    {
        public static readonly ISet<Driver> _driver = new HashSet<Driver>();
        
        public Task CreateDriverAsync(Driver driver)
        {
            _driver.Add(driver);
            return Task.CompletedTask;
        }

        public async Task<Driver> GetDriverAsync(Guid userId)
        {
            return await Task.FromResult(_driver.SingleOrDefault(p=>p.UserId == userId));
        }
    }
}