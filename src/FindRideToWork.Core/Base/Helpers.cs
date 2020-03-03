using System.Text.RegularExpressions;

namespace FindRideToWork.Core.Base
{
    public static class Helpers
    {
        public static Regex usernameRegex = new Regex(@"^(?=.{5,15}$)([A-Za-z0-9][._()\[\]-]?)*$");
        public static Regex emailRegex = new Regex(@"");
    }
}