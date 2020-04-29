using System;
using Moq;
using PacmanGame;
using PacmanGame.Business.Characters;
using PacmanGame.Client.UserInterface;
using PacmanGame.Data;
using PacmanGame.Data.Enums;
using Xunit;

namespace PacmanGameTests {
    public class PacmanTests {
        [Theory (DisplayName = "Pacman should output correctly given its current direction")]
        [InlineData(Direction.Up, SpriteData.PacUp)]
        [InlineData(Direction.Down, SpriteData.PacDown)]
        [InlineData(Direction.Left, SpriteData.PacLeft)]
        [InlineData(Direction.Right, SpriteData.PacRight)]
        
        public void PacmanShouldDisplayCorrectlyGivenItsCurrentDirection(Direction direction, string display) {
            var pacman = new Pacman(0, 0, direction, new ConsoleOutput());

            Assert.Equal(display, pacman.Sprite);
        }

        [Theory(DisplayName = "Pacman's Sprite changes depending on key presses")]
        [InlineData(Direction.Up, SpriteData.PacUp)]
        [InlineData(Direction.Down, SpriteData.PacDown)]
        [InlineData(Direction.Left, SpriteData.PacLeft)]
        [InlineData(Direction.Right, SpriteData.PacRight)]

        public void PacmansDisplayChangesDependingOnKeyPresses(Direction direction, string display) {
            var mock = new Mock<IInput>();
            var pacman = new Pacman(0, 0, Direction.Right, new ConsoleOutput());
            mock.Setup(m => m.TakeInput(pacman.Direction)).Returns(direction);
            pacman.Update(direction, 1);
            
            Assert.Equal(display, pacman.Sprite);
        }

        // [Theory(DisplayName = "Pacman should move according to its direction and velocity")]
        // [InlineData(Direction.Right, 1, 3, 2)]
        // [InlineData(Direction.Left, 1, 1, 2)]
        // [InlineData(Direction.Up, 1, 2, 1)]
        // [InlineData(Direction.Down, 1, 2, 3)]
        // [InlineData(Direction.Right, 0, 2, 2)]
        // [InlineData(Direction.Left, 0, 2, 2)]
        // [InlineData(Direction.Up, 0, 2, 2)]
        // [InlineData(Direction.Down, 0, 2, 2)]
        //
        //
        // public void PacmanShouldMoveAccordingToItsDirectionAndVelocity(Direction direction, int velocity, int expectedX, int expectedY) {
        //
        //     var pacman = new Pacman(2, 2, Direction.Right, new KeyInput(), new ConsoleOutput());
        //     
        //     pacman.Update(direction, velocity);
        //     pacman.ChooseDirection();
        //     
        //     Assert.Equal(expectedX, pacman.X);
        //     Assert.Equal(expectedY, pacman.Y);
        // }
    }
}