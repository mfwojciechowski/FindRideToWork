namespace FindRideToWork.Infrastructure.Auth
{
    public class IdentityJsonToken : JsonWebToken
    {
        public string RefreshToken{ get; set; }
    }
}