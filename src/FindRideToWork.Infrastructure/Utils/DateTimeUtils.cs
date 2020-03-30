using System;

namespace FindRideToWork.Infrastructure.Utils
{
    public static class DateTimeUtils
    {
        public static string ToTimestamp(this DateTime datetime)
        {
            long ticks = datetime.Ticks - DateTime.Parse("01/01/1970 00:00:00").Ticks;
            ticks /= 10000000;
            
            return ticks.ToString();
        }
    }
}