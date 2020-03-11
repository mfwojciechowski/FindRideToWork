namespace FindRideToWork.Infrastructure.Commands.Users
{
    public class CreateUser : ICommand
    {
        public string Username { get; set; }
        public string Password { get; set; }
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