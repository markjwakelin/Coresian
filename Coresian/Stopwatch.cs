using System;
using Coresian.Interfaces.MsAbstractions.System.Diagnostics;
using MsStopwatch = System.Diagnostics.Stopwatch;

namespace Coresian.MsAbstractions.System.Diagnostics
{
    public class Stopwatch : IStopwatch
    {
        private MsStopwatch _internalStopwatch;
    
        public Stopwatch(MsStopwatch stopwatch){
            _internalStopwatch = stopwatch;
        }
    
        public void Start() {
            _internalStopwatch.Start();
        }
        public void Stop(){
            _internalStopwatch.Stop();        
        }
        public void Restart(){
            _internalStopwatch.Restart();        
        }
        public void Reset(){
            _internalStopwatch.Reset();        
        }
        public bool IsRunning => _internalStopwatch.IsRunning;
        public TimeSpan Elapsed => _internalStopwatch.Elapsed;
    }
}
