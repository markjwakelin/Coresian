using System;
using Coresian.Interfaces.Providers;

namespace Coresian.Providers
{
    public class DateTimeProvider : IDateTimeProvider
    {
        public DateTime GetLocalTime()
        {
            return DateTime.Now.ToLocalTime();
        }

        public DateTime GetUtcTime()
        {
            return DateTime.Now.ToUniversalTime();
        }
    }
}
