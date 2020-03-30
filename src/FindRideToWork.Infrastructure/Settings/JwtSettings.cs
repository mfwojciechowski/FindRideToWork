namespace FindRideToWork.Infrastructure.Settings
{
    public class JwtSettings
    {
        public string AuthKey { get; set; }
        public int ExpiryMinutes { get; set; }
        public string Issuer { get; set; }
    }
}