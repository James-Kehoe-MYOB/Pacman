namespace PacmanGame {
    public class Game : IGame {
        public bool HasWon { get; set; } = false;
        public int PelletCount { get; set; }

        public void CheckWin() {
            if (PelletCount == 0) {
                HasWon = true;
            }
        }
    }
}