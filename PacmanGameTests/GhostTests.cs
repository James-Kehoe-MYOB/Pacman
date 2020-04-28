using System.Collections.Generic;
using PacmanGame;
using PacmanGame.Business.Characters;
using PacmanGame.Business.Game;
using PacmanGame.Business.GhostLogic;
using PacmanGame.Client.UserInterface;
using PacmanGame.Data.Board_Data;
using PacmanGame.Data.Enums;
using PacmanGame.DataAccess.BoardLayoutConverter;
using Xunit;

namespace PacmanGameTests {
    public class GhostTests {
        [Fact(DisplayName = "Ghost should Initialise in the correct position on the board")]

        public void GhostShouldInitialiseInTheCorrectPositionOnBoard() {
            
            var converter = new BinaryToBoardLayoutConverter();
            
            var rawData = "000" +
                          "000" +
                          "000";

            var layout = converter.Convert(3, 3, rawData);
            
            
            var expectedGhost = new Ghost(new Coords{x = 2, y = 2}, Direction.Right, new RandomGhostLogic());
            
            var ghosts = new List<Ghost> {
                new Ghost(new Coords{
                    x = 2,
                    y = 2
                }, Direction.Right, new RandomGhostLogic())
            };
            
            var game = new Game(new Board(3, 3, 1, 1, Direction.Right, ghosts,layout), new KeyInput(), new ConsoleDisplay(), new GameTimer());
            
            Assert.Equal(expectedGhost.X, game.Ghosts[0].X);
            Assert.Equal(expectedGhost.Y, game.Ghosts[0].Y);
        }
    }
}