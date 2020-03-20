using System.Threading.Tasks;

namespace FindRideToWork.Infrastructure.Services
{
    public interface ILoginService
    {
        Task<bool> SignIn(string email, string password);
    }
}