using System;

namespace Coresian.Interfaces.Providers
{
    public interface IDateTimeProvider
    {
        DateTime GetLocalTime();

        DateTime GetUtcTime();
    }
}
