using System;
using System.Collections.Generic;
using System.Linq;
using System.Timers;
using PacmanGame.Business.Characters;
using PacmanGame.Business.GameObjects;
using PacmanGame.Client.UserInterface;
using PacmanGame.Data;
using PacmanGame.Data.Board_Data;
using PacmanGame.Data.Enums;

namespace PacmanGame.Business.Game {
    public class Game : IGame {
        public bool HasWon { get; set; } = false;
        public Board Board { get; private set; }
        public Pacman Pacman { get; set; }
        public GameState State { get; set; }
        public List<Pellet> ActivePellets { get; set; } = new List<Pellet>();
        public List<Ghost> Ghosts { get; set; }
        public IInput InputHandler { get; set; }
        public IDisplay DisplayHandler { get; set; }
        public ITimer GameTimer { get; set; } 

        public Game(Board defaultBoard, IInput inputHandler, IDisplay displayHandler, ITimer gameTimer) {
            InputHandler = inputHandler;
            DisplayHandler = displayHandler;
            GameTimer = gameTimer;
            GameTimer.InitTimer(200, Step);
            Pacman = new Pacman(new Coords {x = defaultBoard.PacStartX, y = defaultBoard.PacStartY}, defaultBoard.PacStartDirection, displayHandler);
            Ghosts = defaultBoard.Ghosts;
            HasWon = false;
            LoadBoard(defaultBoard);
        }

        public void Run() {
            ResetCharacters();
            DisplayHandler.WriteBoard(Board);
            DisplayHandler.WriteGameObjects(Pacman, ActivePellets, Ghosts);
            System.Threading.Thread.Sleep(1000);
            
            GameTimer.Start();
            State = GameState.Running;
            
            while (State == GameState.Running) {
                if (InputHandler.KeyAvailable()) {
                    var newDirection = InputHandler.TakeInput(Pacman);
                    ChangePacmanDirection(newDirection);
                }
            }
            
            GameTimer.Stop();
        }
        
        public void LoadBoard(Board board) {
            State = GameState.Initialising;
            Board = board;
            Ghosts = board.Ghosts;
            ResetCharacters();
            FillPellets();
            HasWon = false;
        }
        
        private void Step(object source, ElapsedEventArgs e) {
            UpdateBoard();
            CheckWin();
        }

        public void CheckWin() {
            if (ActivePellets.Count == 0) {
                HasWon = true;
                State = GameState.Finished;
            }
            else if (PacmanTouchingGhost()) {
                HasWon = false;
                State = GameState.Finished;
            }
            else {
                HasWon = false;
                State = GameState.Running;
            }
        }
        
        private void FillPellets() {
            ActivePellets.Clear();
            var emptySpots = Board.Layout.Where(m => m.State == TileState.Empty);
            foreach (var tile in emptySpots) {
                if (!(tile.X == Pacman.X && tile.Y == Pacman.Y)) {
                    ActivePellets.Add(new Pellet(new Coords{x = tile.X, y = tile.Y}));
                }
            }
        }

        private void ChangePacmanDirection(Direction direction) {
            if (CheckWallCollision(direction, Pacman)) return;
            Pacman.Direction = direction;
            Pacman.Velocity = 1;
        }

        public void UpdateBoard() {
            UpdatePacmanPosition();
            CheckWin();
            UpdatePelletList();
            UpdateGhostPositions();
            
            DisplayHandler.WriteGameObjects(Pacman, ActivePellets, Ghosts);
        }

        private void UpdatePacmanPosition() {
            if (CheckWallCollision(Pacman.Direction, Pacman)) {
                Pacman.Velocity = 0;
            }
            Pacman.Sprite = DisplayHandler.UpdatePacmanSprite(Pacman.Direction);
            DisplayHandler.ClearTileDisplay(Pacman.X, Pacman.Y, Board);
            Move(Pacman);
        }

        private bool PacmanTouchingGhost() {
            return Ghosts.Any(ghost => Pacman.X == ghost.X && Pacman.Y == ghost.Y);
        }

        private void UpdatePelletList() {
            var pacPosition = ActivePellets.Find(m => m.X == Pacman.X && m.Y == Pacman.Y);
            ActivePellets.Remove(pacPosition);
        }

        private void UpdateGhostPositions() {
            foreach (var ghost in Ghosts) {
                ghost.Velocity = 1;
                DisplayHandler.ClearTileDisplay(ghost.X, ghost.Y, Board);
                while (CheckWallCollision(ghost.Direction, ghost)) {
                    ghost.Direction = ghost.ChooseDirection();
                }
                Move(ghost);
            }
        }

        private bool CheckWallCollision(Direction direction, Character character) {
            var collision = new Collision(character) {Direction = direction};
            Move(collision);
            return Board.Layout.Find(m => m.X == collision.X && m.Y == collision.Y).State == TileState.Wall;
        }
        
        private void ResetCharacters() {
            Pacman.X = Board.PacStartX;
            Pacman.Y = Board.PacStartY;
            Pacman.Update(Board.PacStartDirection, 1);
            
            for (int i = 0; i < Ghosts.Count; i++) {
                Ghosts[i].X = Board.Ghosts[i].X;
                Ghosts[i].Y = Board.Ghosts[i].Y;
            }
        }

        private void Move(Character character) {
            
            switch (character.Direction) {
                case Direction.Up:
                    if (character.Y == 1 && character.Velocity == 1) {
                        character.Y = Board.Height;
                    }
                    else {
                        character.Y -= character.Velocity;
                    }
                    break;
                case Direction.Down:
                    if (character.Y == Board.Height && character.Velocity == 1) {
                        character.Y = 1;
                    }
                    else {
                        character.Y += character.Velocity;
                    }
                    break;
                case Direction.Left:
                    if (character.X == 1 && character.Velocity == 1) {
                        character.X = Board.Width;
                    }
                    else {
                        character.X -= character.Velocity;
                    }
                    break;
                case Direction.Right:
                    if (character.X == Board.Width && character.Velocity == 1) {
                        character.X = 1;
                    }
                    else {
                        character.X += character.Velocity;
                    }
                    break;
                default:
                    throw new Exception();
            }
            DisplayHandler.WriteSprite(character);
        }
    }
}