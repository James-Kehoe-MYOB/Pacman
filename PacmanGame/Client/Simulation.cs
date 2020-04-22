namespace PacmanGame.Client {
    public class Simulation {
        public int Lives { get; set; }
        public bool GameOver { get; set; } = false;
        private IGame Game { get; set; }

        public Simulation(int lives, IGame game) {
            Lives = lives;
            Game = game;
        }

        public void StartGame() {
            while (Lives > 0) {
                //Foreach dataset in LevelData
                //Game.InitBoard(dataset)
                //Game.RunGame
                UpdateLives();
            }

            GameOver = true;
            
        }

        public void UpdateLives() {
            if (Game.HasWon == false) {
                Lives--;
            }
        }

    }
}