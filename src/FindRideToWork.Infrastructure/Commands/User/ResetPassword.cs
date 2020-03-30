namespace FindRideToWork.Infrastructure.Commands.User
{
    public class ResetPassword : ICommand
    {
        public string Email { get; set; }
    }
}