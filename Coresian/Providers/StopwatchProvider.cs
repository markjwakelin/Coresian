
using System;
using Coresian.Interfaces.Providers;
using Coresian.Interfaces.MsAbstractions.System.Diagnostics;
using Coresian.MsAbstractions.System.Diagnostics;
using MsStopwatch = System.Diagnostics.Stopwatch;

namespace Coresian.Providers
{
    public class StopwatchProvider : IStopwatchProvider
    {
        public IStopwatch GetStopwatch(){
          return new Stopwatch(new MsStopwatch());
        }
    }
}
