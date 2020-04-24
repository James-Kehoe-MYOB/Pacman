using System.Collections.Generic;
using PacmanGame;
using PacmanGame.Client.UserInterface;
using PacmanGame.Data.Enums;
using Xunit;

namespace PacmanGameTests {
    public class GameTests {
        [Theory(DisplayName = "Game is only won if all pellets are eaten")]
        [InlineData(0, false)]
        [InlineData(1, true)]

        public void GameIsOnlyWonIfAllPelletsAreEaten(int steps, bool hasWon) {

            var boardData = new List<Tile> {
                new Tile(1, 1, TileState.Empty),
                new Tile(2, 1, TileState.Empty),
                new Tile(1, 2, TileState.Wall),
                new Tile(2, 2, TileState.Wall)
            };

            var game = new Game(new GameBoard(2, 2, 1, 1, Direction.Right, boardData), new KeyInput(), new ConsoleDisplay());
            
            for (int i = 0; i < steps; i++) {
                game.UpdateBoard();
            }

            game.CheckWin();
            
            Assert.Equal(hasWon, game.HasWon);
        }

        [Fact(DisplayName = "Game can initialise gameboard with given boarddata")]

        public void GameCanInitialiseGameBoardWithGivenBoardData() {
            var boarddata = new List<Tile> {
                new Tile(1, 1, TileState.Wall),
                new Tile(2, 1, TileState.Empty),
                new Tile(1, 2, TileState.Empty),
                new Tile(2, 2, TileState.Wall)
            };
            
            var board = new GameBoard(2, 2, 1, 1, Direction.Right, boarddata);
            
            var game = new Game(board, new KeyInput(), new ConsoleDisplay());

            Assert.Equal(board, game.Board);
        }

        [Theory(DisplayName = "Pacman can only move if not colliding with wall")]
        [InlineData(TileState.Wall, 1)]
        [InlineData(TileState.Empty, 2)]

        public void PacmanCanOnlyMoveIfNotCollidingWithWall(TileState isWall, int x) {
            var boarddata = new List<Tile> {
                new Tile(1, 1, TileState.Empty),
                new Tile(2, 1, isWall)
            };
            var board = new GameBoard(2, 1, 1, 1, Direction.Right, boarddata);
            
            var game = new Game(board, new KeyInput(), new ConsoleDisplay());

            game.UpdateBoard();
            
            Assert.Equal(x, game.Pacman.X);
            Assert.Equal(1, game.Pacman.Y);

        }

        [Fact(DisplayName = "Pellet Count Updates When Initialising Board")]
        public void PelletCountUpdatesWhenInitialisingBoard() {
            var boarddata = new List<Tile> {
                new Tile(1, 1, TileState.Wall),
                new Tile(2, 1, TileState.Wall),
                new Tile(3, 1, TileState.Wall),
                new Tile(1, 2, TileState.Wall),
                new Tile(2, 2, TileState.Empty),
                new Tile(3, 2, TileState.Empty),
                new Tile(1, 3, TileState.Wall),
                new Tile(2, 3, TileState.Wall),
                new Tile(3, 3, TileState.Wall)
            };
            
            var board = new GameBoard(3, 3, 2, 2, Direction.Right, boarddata);
            
            var game = new Game(board, new KeyInput(), new ConsoleDisplay());
            
            game.LoadBoard(board);

            Assert.Single(game.PelletList);
        }

        [Fact(DisplayName = "PacmanEatingPelletUpdatesPelletCount")]
        public void PacmanEatingPelletUpdatesPelletCount() {
            var boarddata = new List<Tile> {
                new Tile(1, 1, TileState.Wall),
                new Tile(2, 1, TileState.Wall),
                new Tile(3, 1, TileState.Wall),
                new Tile(1, 2, TileState.Wall),
                new Tile(2, 2, TileState.Empty),
                new Tile(3, 2, TileState.Empty),
                new Tile(1, 3, TileState.Wall),
                new Tile(2, 3, TileState.Wall),
                new Tile(3, 3, TileState.Wall)
            };
            
            var board = new GameBoard(3, 3, 2, 2, Direction.Right, boarddata);
            
            var game = new Game(board, new KeyInput(), new ConsoleDisplay());
            
            game.LoadBoard(board);
            
            game.UpdateBoard();
            
            Assert.Empty(game.PelletList);
        }

        [Fact(DisplayName = "Pacman should wrap around the screen")]
        public void PacmanShouldWrapAroundTheScreen() {
            var boarddata = new List<Tile> {
                new Tile(1, 1, TileState.Empty),
                new Tile(2, 1, TileState.Empty),
                new Tile(1, 2, TileState.Empty),
                new Tile(2, 2, TileState.Empty),
            };
            
            var board = new GameBoard(2, 2, 2, 1, Direction.Up, boarddata);
            
            var game = new Game(board, new KeyInput(), new ConsoleDisplay());

            game.UpdateBoard();
            
            Assert.Equal(2, game.Pacman.X);
            Assert.Equal(2, game.Pacman.Y);
        }
    }
}