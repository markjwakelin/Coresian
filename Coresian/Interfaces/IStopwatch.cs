using System;

namespace Coresian.Interfaces.MsAbstractions.System.Diagnostics
{
    public interface IStopwatch
    {
        void Start();
        void Stop();
        void Restart();
        void Reset();
        bool IsRunning {get;}
        TimeSpan Elapsed {get;}
    }
}
