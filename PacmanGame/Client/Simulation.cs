using System;
using PacmanGame.Business.Game;
using PacmanGame.Client.UserInterface;
using PacmanGame.Data.Board_Data;

namespace PacmanGame.Client {
    public class Simulation {
        public int Lives { get; set; }
        public bool GameOver { get; private set; }
        private IGame Game { get; set; }
        private LevelSet LevelSet { get; set; }

        private IDisplay Display { get; set; }

        public Simulation(int lives, IGame game, LevelSet levelSet, IDisplay display) {
            Lives = lives;
            Game = game;
            LevelSet = levelSet;
            GameOver = false;
            Display = display;
        }

        public void StartGame() {

            foreach (var level in LevelSet) {
                Game.LoadBoard(level);
                while (!Game.HasWon && Lives > 0) {
                    Console.Clear();
                    Console.SetCursorPosition(1, 1);
                    Display.WriteLives(Lives);
                    Game.Run();
                    UpdateLives();
                }
            }

            GameOver = true;
            Console.Clear();
            Console.WriteLine("Game Over! Thank You For Playing!");
            
        }

        public void UpdateLives() {
            
            if (Game.HasWon == false) {
                Lives--;
            }
            
        }

    }
}