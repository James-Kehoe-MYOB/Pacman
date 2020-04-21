using Moq;
using PacmanGame;
using Xunit;

namespace PacmanGameTests {
    public class SimulationTests {
        [Fact(DisplayName = "Running out of Lives Results in a Game Over")]

        public void RunningOutOfLivesResultsInAGameOver() {
            var sim = new Simulation(3, new Level());

            sim.Lives = 0;
            sim.StartGame();
            
            Assert.True(sim.GameOver);
        }

        [Fact(DisplayName = "Failing in a level depletes one life")] 
        
        public void FailingInALevelDepletesOneLife() {
            var mock = new Mock<ILevel>();
            mock.Setup(m => m.HasWon).Returns(false);

            var sim = new Simulation(3, mock.Object);
            sim.UpdateLives();
            
            Assert.Equal(2, sim.Lives);
        }
    }
}