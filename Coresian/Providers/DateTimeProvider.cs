using System;
using Coresian.Interfaces.Providers;

namespace Coresian.Providers
{
    public class DateTimeProvider : IDateTimeProvider
    {
        public DateTime GetLocal()
        {
            return DateTime.Now.ToLocalTime();
        }

        public DateTime GetUtc()
        {
            return DateTime.Now.ToUniversalTime();
        }
    }
}
