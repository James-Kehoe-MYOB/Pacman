using System.Collections.Generic;
using Moq;
using PacmanGame;
using PacmanGame.Client;
using PacmanGame.Data.Enums;
using PacmanGame.UserInterface;
using Xunit;

namespace PacmanGameTests {
    public class SimulationTests {
        [Fact(DisplayName = "Running out of Lives Results in a Game Over")]

        public void RunningOutOfLivesResultsInAGameOver() {
            var sim = new Simulation(3, new Game(new GameBoard(1, 1, 1, 1, Direction.Right, new List<Tile>()), new ConsoleUI()));

            sim.Lives = 0;
            sim.StartGame();
            
            Assert.True(sim.GameOver);
        }

        [Fact(DisplayName = "Failing in a game depletes one life")] 
        
        public void FailingInALevelDepletesOneLife() {
            var mock = new Mock<IGame>();
            mock.Setup(m => m.HasWon).Returns(false);

            var sim = new Simulation(3, mock.Object);
            sim.UpdateLives();
            
            Assert.Equal(2, sim.Lives);
        }
    }
}