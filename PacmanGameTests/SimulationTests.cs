using System.Collections.Generic;
using Moq;
using PacmanGame;
using PacmanGame.Business.Characters;
using PacmanGame.Business.Engine;
using PacmanGame.Business.Engine.Timer;
using PacmanGame.Business.GameObjects;
using PacmanGame.Client;
using PacmanGame.Client.UserInterface;
using PacmanGame.Data.Enums;
using PacmanGame.Data.LevelData;
using Xunit;

namespace PacmanGameTests {
    public class SimulationTests {
        [Fact(DisplayName = "Running out of Lives Results in a Game Over")]

        public void RunningOutOfLivesResultsInAGameOver() {
            var data = new LevelLayout {
                new Tile(1, 1, TileState.Empty)
            };
            
            var sim = new Game(3, new Engine(new Level(1, 1, 1, 1, Direction.Right, new List<Ghost>(), data), new KeyInput(), new ConsoleOutput(), new GameTimer()), new LevelSet(), new ConsoleOutput());

            sim.Lives = 0;
            sim.StartGame();
            
            Assert.True(sim.GameOver);
        }

        [Fact(DisplayName = "Failing in a game depletes one life")] 
        
        public void FailingInALevelDepletesOneLife() {
            var mock = new Mock<IEngine>();
            mock.Setup(m => m.HasWon).Returns(false);

            var sim = new Game(3, mock.Object, new LevelSet(), new ConsoleOutput());
            sim.UpdateLives();
            
            Assert.Equal(2, sim.Lives);
        }
    }
}