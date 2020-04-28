using System;
using System.Timers;

namespace PacmanGame {
    public class GameTimer : ITimer {
        
        private Timer _Timer = new Timer();
        public int Interval { get; set; }

        public void InitTimer(int interval, ElapsedEventHandler function) {
            _Timer = new Timer();
            _Timer.Elapsed += function;
            _Timer.Interval = interval;
            _Timer.AutoReset = true;
        }

        public void Start() {
            _Timer.Start();
        }

        public void Stop() {
            _Timer.Stop();
        }
    }
}