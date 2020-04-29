using System.Timers;

namespace PacmanGame.Business.Engine.Timer {
    public interface ITimer {

        void InitTimer(int interval, ElapsedEventHandler function);
        
        void Start();

        void Stop();
    }
}