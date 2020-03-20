namespace FindRideToWork.Infrastructure.Commands.User
{
    public class CreateUser : ICommand
    {
        public string Password { get; set;  }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int RoleId
        { 
            get 
            {
                return 1;
            }
        }
    }
}