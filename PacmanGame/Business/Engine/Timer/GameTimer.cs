using System.Timers;

namespace PacmanGame.Business.Engine.Timer {
    public class GameTimer : ITimer {
        
        private System.Timers.Timer _timer = new System.Timers.Timer();

        public void InitTimer(int interval, ElapsedEventHandler function) {
            _timer = new System.Timers.Timer();
            _timer.Elapsed += function;
            _timer.Interval = interval;
            _timer.AutoReset = true;
        }

        public void Start() {
            _timer.Start();
        }

        public void Stop() {
            _timer.Stop();
        }
    }
}