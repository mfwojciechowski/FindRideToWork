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

        public Task AddDriverAsync(Driver driver)
        {
            throw new NotImplementedException();
        }

        public Task CreateDriverAsync(Driver driver)
        {
            _driver.Add(driver);
            return Task.CompletedTask;
        }

        public Task CreateDriverRouteAsync(Route route)
        {
            throw new NotImplementedException();
        }

        public async Task<Driver> GetDriverAsync(Guid userId)
        {
            return await Task.FromResult(_driver.SingleOrDefault(p=>p.UserId == userId));
        }

        public Task UpdateDriverAsync(Driver driver)
        {
            throw new NotImplementedException();
        }
    }
}