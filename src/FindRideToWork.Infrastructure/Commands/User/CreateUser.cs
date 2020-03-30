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

        public bool isVerified 
         {
            get 
            {
                return false;
            }
        }

        public int LanguageId
         {
            get 
            {
                return 1;
            }
        }
    }
}