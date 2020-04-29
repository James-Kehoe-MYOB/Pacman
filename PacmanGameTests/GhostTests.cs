using System.Collections.Generic;
using PacmanGame;
using PacmanGame.Business.Characters;
using PacmanGame.Business.Engine;
using PacmanGame.Business.Engine.Timer;
using PacmanGame.Business.GhostLogic;
using PacmanGame.Client.UserInterface;
using PacmanGame.Data.Enums;
using PacmanGame.Data.LevelData;
using PacmanGame.DataAccess.BoardLayoutConverter;
using Xunit;

namespace PacmanGameTests {
    public class GhostTests {
        [Fact(DisplayName = "Ghost should Initialise in the correct position on the level")]

        public void GhostShouldInitialiseInTheCorrectPositionOnBoard() {
            
            var converter = new BinaryToBoardLayoutConverter();
            
            var rawData = "000" +
                          "000" +
                          "000";

            var layout = converter.Convert(3, 3, rawData);
            
            
            var expectedGhost = new Ghost(2, 2, new RandomGhostLogic());
            
            var ghosts = new List<Ghost> {
                new Ghost(2, 2, new RandomGhostLogic())
            };
            
            var game = new Engine(new Level(3, 3, 1, 1, Direction.Right, ghosts,layout), new KeyInput(), new ConsoleOutput(), new GameTimer());
            
            Assert.Equal(expectedGhost.X, game.Ghosts[0].X);
            Assert.Equal(expectedGhost.Y, game.Ghosts[0].Y);
        }
    }
}