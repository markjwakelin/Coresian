using System;
using Coresian.Interfaces.MsAbstractions.System.Diagnostics;

namespace Coresian.Interfaces.Providers
{
    public interface IStopwatchProvider
    {
        IStopwatch GetStopwatch();
    }
}
