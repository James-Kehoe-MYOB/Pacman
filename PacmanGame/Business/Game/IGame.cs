using PacmanGame.Data.Board;

namespace PacmanGame.Business.Game {
    public interface IGame {
        public void LoadBoard(Board board);

        public void Run();
        public bool HasWon { get; set; }
    }
}