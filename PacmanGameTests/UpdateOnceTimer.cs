using System.Timers;
using PacmanGame;

namespace PacmanGameTests {
    public class UpdateOnceTimer : ITimer {
        private Timer _timer = new Timer();
        public int Interval { get; set; }
        public void InitTimer(int interval, ElapsedEventHandler function) {
            _timer.Elapsed += function;
            _timer.Interval = 200;
        }

        public void Start() {
            _timer.AutoReset = false;
            _timer.Start();
        }

        public void Stop() {
            _timer.Stop();
        }
    }
}