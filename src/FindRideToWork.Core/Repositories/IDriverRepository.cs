using System;
using System.Threading.Tasks;
using FindRideToWork.Core.Domain;

namespace FindRideToWork.Core.Repositories
{
    public interface IDriverRepository
    {        
        Task<Driver> GetDriverAsync(Guid userId);
        Task CreateDriverAsync(Driver driver);
    }
}