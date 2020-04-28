using System.Collections.Generic;
using Moq;
using PacmanGame;
using PacmanGame.Business.Characters;
using PacmanGame.Business.Game;
using PacmanGame.Business.GameObjects;
using PacmanGame.Business.GhostLogic;
using PacmanGame.Client.UserInterface;
using PacmanGame.Data.Board_Data;
using PacmanGame.Data.Enums;
using PacmanGame.DataAccess.BoardLayoutConverter;
using Xunit;

namespace PacmanGameTests {
    public class GameTests {
        [Theory(DisplayName = "Game is only won if all pellets are eaten")]
        [InlineData(0, false)]
        [InlineData(1, true)]

        public void GameIsOnlyWonIfAllPelletsAreEaten(int steps, bool hasWon) {

            var boardData = new BoardLayout {
                new Tile(1, 1, TileState.Empty),
                new Tile(2, 1, TileState.Empty),
                new Tile(1, 2, TileState.Wall),
                new Tile(2, 2, TileState.Wall)
            };

            var game = new Game(new Board(2, 2, 1, 1, Direction.Right, new List<Ghost>(),  boardData), new KeyInput(), new ConsoleDisplay(), new GameTimer());
            
            
            for (int i = 0; i < steps; i++) {
                game.UpdateBoard();
            }

            game.CheckWin();
            
            Assert.Equal(hasWon, game.HasWon);
        }

        [Fact(DisplayName = "Game can initialise gameboard with given boarddata")]

        public void GameCanInitialiseGameBoardWithGivenBoardData() {
            var boarddata = new BoardLayout {
                new Tile(1, 1, TileState.Wall),
                new Tile(2, 1, TileState.Empty),
                new Tile(1, 2, TileState.Empty),
                new Tile(2, 2, TileState.Wall)
            };
            
            var board = new Board(2, 2, 1, 1, Direction.Right, new List<Ghost>(),  boarddata);
            
            var game = new Game(board, new KeyInput(), new ConsoleDisplay(), new GameTimer());

            Assert.Equal(board, game.Board);
        }

        [Theory(DisplayName = "Pacman can only move if not colliding with wall")]
        [InlineData(TileState.Wall, 1)]
        [InlineData(TileState.Empty, 2)]

        public void PacmanCanOnlyMoveIfNotCollidingWithWall(TileState isWall, int x) {
            var boarddata = new BoardLayout {
                new Tile(1, 1, TileState.Empty),
                new Tile(2, 1, isWall)
            };
            var board = new Board(2, 1, 1, 1, Direction.Right, new List<Ghost>(),  boarddata);
            
            var game = new Game(board, new KeyInput(), new ConsoleDisplay(), new GameTimer());

            game.UpdateBoard();
            
            Assert.Equal(x, game.Pacman.X);
            Assert.Equal(1, game.Pacman.Y);

        }

        [Fact(DisplayName = "Pellet Count Updates When Initialising Board")]
        public void PelletCountUpdatesWhenInitialisingBoard() {
            var boarddata = new BoardLayout {
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
            
            var board = new Board(3, 3, 2, 2, Direction.Right, new List<Ghost>(),  boarddata);
            
            var game = new Game(board, new KeyInput(), new ConsoleDisplay(), new GameTimer());
            
            game.LoadBoard(board);

            Assert.Single(game.ActivePellets);
        }

        [Fact(DisplayName = "PacmanEatingPelletUpdatesPelletCount")]
        public void PacmanEatingPelletUpdatesPelletCount() {
            var boarddata = new BoardLayout {
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
            
            var board = new Board(3, 3, 2, 2, Direction.Right, new List<Ghost>(),  boarddata);
            
            var game = new Game(board, new KeyInput(), new ConsoleDisplay(), new GameTimer());
            
            game.LoadBoard(board);
            
            game.UpdateBoard();
            
            Assert.Empty(game.ActivePellets);
        }

        [Fact(DisplayName = "Pacman should wrap around the screen")]
        public void PacmanShouldWrapAroundTheScreen() {
            var boarddata = new BoardLayout {
                new Tile(1, 1, TileState.Empty),
                new Tile(2, 1, TileState.Empty),
                new Tile(1, 2, TileState.Empty),
                new Tile(2, 2, TileState.Empty),
            };
            
            var board = new Board(2, 2, 2, 1, Direction.Up, new List<Ghost>(),  boarddata);
            
            var game = new Game(board, new KeyInput(), new ConsoleDisplay(), new GameTimer());

            game.UpdateBoard();
            
            Assert.Equal(2, game.Pacman.X);
            Assert.Equal(2, game.Pacman.Y);
        }

        [Fact(DisplayName = "Game Ends if Pacman Collides with Ghost")]

        public void GameEndsIfPacmanCollidesWithGhost() {
            var rawData = "000";
            var converter = new BinaryToBoardLayoutConverter();

            var layout = converter.Convert(1, 3, rawData);
            var mock = new Mock<IGhostLogic>();
            mock.Setup(m => m.ChooseDirection()).Returns(Direction.Left);

            var ghostlist = new List<Ghost> {
                new Ghost(new Coords {x = 3, y = 1}, Direction.Left, mock.Object)
            };
            
            var mockInput = new Mock<IInput>();
            mockInput.Setup(m => m.KeyAvailable()).Returns(false);
            
            var board = new Board(3, 1, 1, 1, Direction.Right, ghostlist, layout);

            var game = new Game(board, mockInput.Object, new ConsoleDisplay(), new UpdateOnceTimer());
            
            game.Run();
            
            Assert.NotEqual(GameState.Running, game.State);
        }
    }
}