using System;
using System.Net;

namespace ECommerce.Core
{
    public static class Time
    {
        public static TimeSpan CurrentTime = new TimeSpan(0, 0, 0);
        public static string IncreaseTime(int hours)
        {
            IncreaseTimeValidate(hours);
            CurrentTime = new TimeSpan(CurrentTime.Hours + hours, 0, 0);
            return $"Time is {CurrentTime}";
        }
        public static string ResetTime()
        {
            CurrentTime = new TimeSpan(0, 0, 0);
            return $"Time is {CurrentTime}";
        }
        private static void IncreaseTimeValidate(int hours)
        {
            if (hours <= 0)
                throw new ECommerceException("Hours must be greater than zero.", (int)HttpStatusCode.BadRequest);
        }
    }
}