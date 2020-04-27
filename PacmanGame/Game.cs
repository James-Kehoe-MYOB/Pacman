using System;
using System.Collections.Generic;
using System.Linq;
using System.Timers;
using PacmanGame.Client.UserInterface;
using PacmanGame.Data.Enums;

namespace PacmanGame {
    public class Game : IGame {
        public bool HasWon { get; set; } = false;
        public GameBoard Board { get; private set; }
        public Pacman Pacman { get; set; }
        public GameState State { get; set; }
        private Direction CurrentDirection { get; set; }
        private int CurrentVelocity { get; set; }
        public List<Pellet> ActivePellets { get; set; } = new List<Pellet>();
        public IInput InputHandler { get; set; }
        public IDisplay DisplayHandler { get; set; }

        public Game(GameBoard board, IInput inputHandler, IDisplay displayHandler) {
            InputHandler = inputHandler;
            DisplayHandler = displayHandler;
            Pacman = new Pacman(board.PacStartX, board.PacStartY, board.PacStartDirection, inputHandler, displayHandler);
            CurrentDirection = board.PacStartDirection;
            CurrentVelocity = 1;
            LoadBoard(board);
        }

        public void Run() {
            DisplayHandler.WriteBoard(Board);
            FillPellets();
            Console.SetCursorPosition(Pacman.X*3-2, Pacman.Y);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(Pacman.Display);
            
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

        public void LoadBoard(GameBoard board) {
            State = GameState.Initialising;
            Board = board;
            ResetPacman();
            FillPellets();
        }

        private void FillPellets() {
            ActivePellets.Clear();
            var emptySpots = Board.Data.Where(m => m.State == TileState.Empty);
            foreach (var tile in emptySpots) {
                if (!(tile.X == Pacman.X && tile.Y == Pacman.Y)) {
                    ActivePellets.Add(new Pellet(tile.X, tile.Y));
                }
            }
            DisplayHandler.DisplayPellets(this);
        }

        private void SetDirectionAndVelocity(Direction direction) {
            if (CheckCollision(direction) == TileState.Wall) return;
            CurrentDirection = direction;
            CurrentVelocity = 1;
        }

        public void UpdateBoard() {
            if (CheckCollision(CurrentDirection) == TileState.Wall) {
                CurrentVelocity = 0;
            }
            DisplayHandler.DisplayPellets(this);
            Console.SetCursorPosition(Pacman.X*3-2, Pacman.Y);
            Console.Write("   ");
            Pacman.Update(CurrentDirection, CurrentVelocity);
            MovePacman(Pacman);
            Console.SetCursorPosition(Pacman.X*3-2, Pacman.Y);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(Pacman.Display);
            if (ActivePellets.Exists(m => m.X == Pacman.X && m.Y == Pacman.Y)) {
                ActivePellets.Remove(ActivePellets.Find(m => m.X == Pacman.X && m.Y == Pacman.Y));
            }
        }

        private TileState CheckCollision(Direction direction) {
            var potentialPac = new Pacman(Pacman.X, Pacman.Y, Pacman.currentDirection, Pacman.Input, Pacman.DisplayHandler);
            potentialPac.Update(direction, 1);
            MovePacman(potentialPac);
            return Board.Data.Find(m => m.X == potentialPac.X && m.Y == potentialPac.Y).State;
        }
        
        private void ResetPacman() {
            Pacman.X = Board.PacStartX;
            Pacman.Y = Board.PacStartY;
            Pacman.currentDirection = Board.PacStartDirection;
        }
        
        public void MovePacman(Pacman pacman) {
            switch (pacman.currentDirection) {
                case Direction.Up:
                    if (pacman.Y == 1 && CurrentVelocity == 1) {
                        pacman.Y = Board.Height;
                    }
                    else {
                        pacman.Y -= CurrentVelocity;
                    }
                    break;
                case Direction.Down:
                    if (pacman.Y == Board.Height && CurrentVelocity == 1) {
                        pacman.Y = 1;
                    }
                    else {
                        pacman.Y += CurrentVelocity;
                    }
                    break;
                case Direction.Left:
                    if (pacman.X == 1 && CurrentVelocity == 1) {
                        pacman.X = Board.Width;
                    }
                    else {
                        pacman.X -= CurrentVelocity;
                    }
                    break;
                case Direction.Right:
                    if (pacman.X == Board.Width && CurrentVelocity == 1) {
                        pacman.X = 1;
                    }
                    else {
                        pacman.X += CurrentVelocity;
                    }
                    break;
                default:
                    throw new Exception();
            }
        }
    }
}