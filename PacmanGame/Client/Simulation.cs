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
                //Game.LoadBoard(dataset)
                //Game.Run
                //if Game.win = false
                //    lives--
                //    reset pacman
                //    game.rungame
                //
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