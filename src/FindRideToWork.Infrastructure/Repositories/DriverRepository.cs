using System;
using System.Threading.Tasks;
using FindRideToWork.Core.Domain;
using FindRideToWork.Core.Repositories;

namespace FindRideToWork.Infrastructure.Repositories
{
    public class DriverRepository : IDriverRepository
    {
        public Task CreateDriverAsync(Driver driver)
        {
            throw new NotImplementedException();
        }

        public Task<Driver> GetDriverAsync(Guid userId)
        {
            throw new NotImplementedException();
        }
    }
}