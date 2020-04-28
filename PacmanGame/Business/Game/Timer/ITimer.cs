using System;
using System.Threading;
using System.Timers;

namespace PacmanGame {
    public interface ITimer {
        public int Interval { get; set; }

        void InitTimer(int interval, ElapsedEventHandler function);
        
        void Start();

        void Stop();
    }
}