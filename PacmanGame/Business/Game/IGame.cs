using PacmanGame.Data.Board_Data;

namespace PacmanGame.Business.Game {
    public interface IGame {
        public void LoadBoard(Board board);
        public void Run();
        public bool HasWon { get; set; }
    }
}