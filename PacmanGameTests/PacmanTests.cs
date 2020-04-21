using System;
using Moq;
using PacmanGame;
using Xunit;

namespace PacmanGameTests {
    public class PacmanTests {
        [Theory (DisplayName = "Pacman should display correctly given its current direction")]
        [InlineData(Direction.Up, Pacman.Up)]
        [InlineData(Direction.Down, Pacman.Down)]
        [InlineData(Direction.Left, Pacman.Left)]
        [InlineData(Direction.Right, Pacman.Right)]
        
        public void PacmanShouldDisplayCorrectlyGivenItsCurrentDirection(Direction direction, char display) {
            var pacman = new Pacman(0, 0, direction, new ConsoleUI());

            Assert.Equal(display, pacman.Display);
        }

        [Theory(DisplayName = "Pacman's Display changes depending on key presses")]
        [InlineData(Direction.Up, Pacman.Up)]
        [InlineData(Direction.Down, Pacman.Down)]
        [InlineData(Direction.Left, Pacman.Left)]
        [InlineData(Direction.Right, Pacman.Right)]

        public void PacmansDisplayChangesDependingOnKeyPresses(Direction direction, char display) {
            var mock = new Mock<IUserInterface>();

            mock.Setup(m => m.TakeInput()).Returns(direction);

            var pacman = new Pacman(0, 0, Direction.Right, mock.Object);
            
            pacman.Update(mock.Object.TakeInput(), 1);
            
            Assert.Equal(display, pacman.Display);
        }

        [Theory(DisplayName = "Pacman should move according to its direction and velocity")]
        [InlineData(Direction.Right, 1, 3, 2)]
        [InlineData(Direction.Left, 1, 1, 2)]
        [InlineData(Direction.Up, 1, 2, 1)]
        [InlineData(Direction.Down, 1, 2, 3)]
        [InlineData(Direction.Right, 0, 2, 2)]
        [InlineData(Direction.Left, 0, 2, 2)]
        [InlineData(Direction.Up, 0, 2, 2)]
        [InlineData(Direction.Down, 0, 2, 2)]
        

        public void PacmanShouldMoveAccordingToItsDirectionAndVelocity(Direction direction, int velocity, int expectedX, int expectedY) {
            var pacman = new Pacman(2, 2, Direction.Right, new ConsoleUI());
            
            pacman.Update(direction, velocity);
            pacman.Move();
            
            Assert.Equal(expectedX, pacman.X);
            Assert.Equal(expectedY, pacman.Y);
        }
    }
}