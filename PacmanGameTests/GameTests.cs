using System.Collections.Generic;
using PacmanGame;
using PacmanGame.Data.Enums;
using PacmanGame.UserInterface;
using Xunit;

namespace PacmanGameTests {
    public class GameTests {
        [Theory(DisplayName = "Game is only won if all pellets are eaten")]
        [InlineData(0, true)]
        [InlineData(20, false)]

        public void GameIsOnlyWonIfAllPelletsAreEaten(int pellets, bool hasWon) {
            
            var game = new Game(new GameBoard(1, 1, 1, 1, Direction.Right, new List<Tile>()), new ConsoleUI()) {
                PelletCount = pellets
            };

            game.CheckWin();
            
            Assert.Equal(hasWon, game.HasWon);
        }

        [Fact(DisplayName = "Game can initialise gameboard with given boarddata")]

        public void GameCanInitialiseGameBoardWithGivenBoardData() {
            var boarddata = new List<Tile> {
                new Tile(1, 1, TileType.Wall),
                new Tile(2, 1, TileType.Empty),
                new Tile(1, 2, TileType.Empty),
                new Tile(2, 2, TileType.Wall)
            };
            
            var board = new GameBoard(2, 2, 1, 1, Direction.Right, boarddata);
            
            var game = new Game(board, new ConsoleUI());

            Assert.Equal(board, game.Board);
        }

        [Theory(DisplayName = "Pacman can only move if not colliding with wall")]
        [InlineData(TileType.Wall, 1)]
        [InlineData(TileType.Empty, 2)]

        public void PacmanCanOnlyMoveIfNotCollidingWithWall(TileType isWall, int x) {
            var boarddata = new List<Tile> {
                new Tile(1, 1, TileType.Empty),
                new Tile(2, 1, isWall)
            };
            var board = new GameBoard(2, 1, 1, 1, Direction.Right, boarddata);
            
            var game = new Game(board, new ConsoleUI());

            game.Update();
            
            Assert.Equal(x, game.Pacman.X);
            Assert.Equal(1, game.Pacman.Y);

        }

        // [Fact(DisplayName = "Pacman can change direction given an input")]
        //
        // public void PacmanCanChangeDirectionGivenAnInput() {
        //     
        // }
    }
}