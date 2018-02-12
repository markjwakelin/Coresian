using System;

namespace Coresian.Interfaces.Providers
{
    public interface IDateTimeProvider
    {
        DateTime GetLocal();

        DateTime GetUtc();
    }
}
