using PacmanGame.Data.LevelData;

namespace PacmanGame.Business.Engine {
    public interface IEngine {
        void LoadLevel(Level level);
        void Run();
        bool HasWon { get; }
    }
}