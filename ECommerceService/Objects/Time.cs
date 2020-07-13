using System;

namespace ECommerceService
{
    public static class Time
    {
        public static TimeSpan CurrentTime = new TimeSpan(0, 0, 0);
        public static string IncreaseTime(int hours)
        {
            CurrentTime = new TimeSpan(CurrentTime.Hours + hours, 0, 0);
            return $"Time is {CurrentTime}";
        }
        public static void ResetTime()
        {
            CurrentTime = new TimeSpan(0, 0, 0);
        }
        // aynı anda birden fazla kez çağrılırsa zaman üst üste arttırılmış olcak, kontrol nasıl?
    }
}