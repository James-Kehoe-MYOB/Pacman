using PacmanGame.Business.Engine;
using PacmanGame.Client.UserInterface;
using PacmanGame.Data.LevelData;

namespace PacmanGame.Client {
    public class Game {
        public int Lives { get; set; }
        public bool GameOver { get; private set; }
        private IEngine Engine { get; }
        private LevelSet LevelSet { get; }
        private IOutput Output { get; }

        public Game(int lives, IEngine engine, LevelSet levelSet, IOutput output) {
            Lives = lives;
            Engine = engine;
            LevelSet = levelSet;
            GameOver = false;
            Output = output;
        }

        public void StartGame() {

            foreach (var level in LevelSet) {
                Engine.LoadLevel(level);
                while (!Engine.HasWon && Lives > 0) {
                    
                    Output.WriteLives(Lives);
                    Engine.Run();
                    UpdateLives();
                }
            }

            GameOver = true;
            Output.WriteGameOver();
            
        }

        public void UpdateLives() {
            
            if (Engine.HasWon == false) {
                Lives--;
            }
            
        }

    }
}