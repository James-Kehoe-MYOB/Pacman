namespace PacmanGame {
    public class Simulation {
        public int Lives { get; set; }
        public bool GameOver { get; set; } = false;

        private ILevel Level { get; set; }

        public Simulation(int lives, ILevel level) {
            Lives = lives;
            Level = level;
        }

        public void StartGame() {
            while (Lives > 0) {
                //Foreach dataset in LevelData
                //Level.InitBoard(dataset)
                //Level.RunGame
                UpdateLives();
            }

            GameOver = true;
            
        }

        public void UpdateLives() {
            if (Level.HasWon == false) {
                Lives--;
            }
        }

    }
}