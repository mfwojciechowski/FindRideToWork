using System.Threading.Tasks;

namespace FindRideToWork.Infrastructure.Commands
{
    public interface ICommandHandler<T> where T : ICommand
    {
         Task HandleAsync(T command);
    }
}