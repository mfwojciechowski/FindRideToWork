using System.Collections.Generic;
using System.Threading.Tasks;
using FindRideToWork.Core.Domain;

namespace FindRideToWork.Core.Repositories
{
    public interface IRouteRepository
    {
        Task<IEnumerable<SingularRoute>> GetSingularRoutesAsync();

        Task AddSingularRouteAsync(SingularRoute singularRoute);
    }
}