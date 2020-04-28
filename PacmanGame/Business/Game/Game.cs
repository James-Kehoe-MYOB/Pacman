using System;
using System.Collections.Generic;
using System.Linq;
using System.Timers;
using PacmanGame.Business.Characters;
using PacmanGame.Business.GameObjects;
using PacmanGame.Client.UserInterface;
using PacmanGame.Data.Board;
using PacmanGame.Data.Enums;

namespace PacmanGame.Business.Game {
    public class Game : IGame {
        public bool HasWon { get; set; } = false;
        public Board Board { get; private set; }
        public Pacman Pacman { get; set; }
        public GameState State { get; set; }
        private Direction CurrentDirection { get; set; }
        private int CurrentVelocity { get; set; }
        public List<Pellet> ActivePellets { get; set; } = new List<Pellet>();
        public List<Ghost> Ghosts { get; set; }
        public IInput InputHandler { get; set; }
        public IDisplay DisplayHandler { get; set; }

        public Game(Board board, IInput inputHandler, IDisplay displayHandler) {
            InputHandler = inputHandler;
            DisplayHandler = displayHandler;
            Pacman = new Pacman(new Coords {x = board.PacStartX, y = board.PacStartY}, board.PacStartDirection, displayHandler);
            CurrentDirection = board.PacStartDirection;
            CurrentVelocity = 1;
            Ghosts = board.Ghosts;
            LoadBoard(board);
        }

        public void Run() {
            ResetPacman();
            DisplayHandler.WriteBoard(Board);
            DisplayHandler.DisplayPellets(ActivePellets, Ghosts);
            DisplayHandler.WriteSprite(Pacman);
            
            
            System.Threading.Thread.Sleep(1000);
            Console.Beep();
            State = GameState.Running;
            
            var timer = new Timer(200) {Enabled = true, AutoReset = true};
            timer.Elapsed += OnTimedEvent;
            timer.Start();
            while (State == GameState.Running) {
                if (!Console.KeyAvailable) {
                    SetDirectionAndVelocity(InputHandler.TakeInput(Pacman));
                }
                CheckWin();
            }
            timer.Stop();
            timer.Enabled = false;
            timer.Dispose();
        }
        
        private void OnTimedEvent(object source, ElapsedEventArgs e) {
            UpdateBoard();
        }

        public void CheckWin() {
            if (ActivePellets.Count == 0) {
                HasWon = true;
                State = GameState.Finished;
            }
            else {
                HasWon = false;
                State = GameState.Running;
            }
        }

        public void LoadBoard(Board board) {
            State = GameState.Initialising;
            Board = board;
            //Ghosts = board.Ghosts;
            ResetPacman();
            FillPellets();
        }

        private void FillPellets() {
            ActivePellets.Clear();
            var emptySpots = Board.Layout.Where(m => m.State == TileState.Empty);
            foreach (var tile in emptySpots) {
                if (!(tile.X == Pacman.X && tile.Y == Pacman.Y)) {
                    ActivePellets.Add(new Pellet(new Coords{x = tile.X, y = tile.Y}));
                }
            }
            DisplayHandler.DisplayPellets(ActivePellets, Ghosts);
        }

        private void SetDirectionAndVelocity(Direction direction) {
            if (CheckCollision(direction, Pacman) == TileState.Wall) return;
            Pacman.Direction = direction;
            Pacman.Velocity = 1;
        }

        public void UpdateBoard() {
            if (CheckCollision(Pacman.Direction, Pacman) == TileState.Wall) {
                Pacman.Velocity = 0;
            }
            Pacman.Sprite = DisplayHandler.UpdatePacmanSprite(Pacman.Direction);

            DisplayHandler.ResetTileDisplay(Pacman.X, Pacman.Y, Board);
            Move(Pacman);
            DisplayHandler.WriteSprite(Pacman);
            
            var pacPosition = ActivePellets.Find(m => m.X == Pacman.X && m.Y == Pacman.Y);
            ActivePellets.Remove(pacPosition);
            Console.ForegroundColor = ConsoleColor.Green;
            foreach (var ghost in Ghosts) {
                ghost.Velocity = 1;
                DisplayHandler.ResetTileDisplay(ghost.X, ghost.Y, Board);
                while (CheckCollision(ghost.Direction, ghost) == TileState.Wall) {
                    ghost.Direction = ghost.ChooseDirection();
                }
                Move(ghost);
                DisplayHandler.WriteSprite(ghost);
            }
            DisplayHandler.DisplayPellets(ActivePellets, Ghosts);
        }

        private TileState CheckCollision(Direction direction, Character character) {
            var collision = new Collision(character) {Direction = direction};
            Move(collision);
            return Board.Layout.Find(m => m.X == collision.X && m.Y == collision.Y).State;
        }
        
        private void ResetPacman() {
            Pacman.X = Board.PacStartX;
            Pacman.Y = Board.PacStartY;
            Pacman.Direction = Board.PacStartDirection;
        }
        
        public void Move(Character character) {
            
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