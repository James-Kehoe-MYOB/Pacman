using PacmanGame.Business.Game;
using PacmanGame.Data.Board;

namespace PacmanGame.Client {
    public class Simulation {
        public int Lives { get; set; }
        public bool GameOver { get; set; } = false;
        private IGame Game { get; set; }
        private LevelSet LevelSet { get; set; }

        public Simulation(int lives, IGame game, LevelSet levelSet) {
            Lives = lives;
            Game = game;
            LevelSet = levelSet;
        }

        public void StartGame() {
            while (Lives > 0) {
                foreach (var level in LevelSet) {
                    Game.LoadBoard(level);
                    Game.Run();
                    UpdateLives();
                }
                //Foreach dataset in LevelData
                //Game.LoadBoard(dataset)
                //Game.Run
                //if Game.win = false
                //    lives--
                //    reset pacman
                //    game.rungame
                //
                
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