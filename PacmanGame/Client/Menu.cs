using System;
using System.IO;
using PacmanGame.Business;
using PacmanGame.Business.Engine;
using PacmanGame.Business.Engine.Timer;
using PacmanGame.DataAccess;

namespace PacmanGame.Client {
    class Menu {
        static void Main(string[] args) {

            GameSettings settings;
            
            try {
                settings = GameSettingsConstructor.LoadSettings(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", "GameSettingsConfig.json"));
            }
            catch (Exception e) {
                Console.WriteLine(e.Message);
                return;
            }

            var input = settings.Input;
            var output = settings.Output;
            var levelSet = settings.LevelSet;
            var lives = settings.Lives;
            
            output.WriteMenu();

            var engine = new Engine(levelSet[0], input, output, new GameTimer());
            var game = new Game(lives, engine, levelSet, output);
            
            game.StartGame();

        }
    }
}