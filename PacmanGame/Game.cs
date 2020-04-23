using System;
using System.Linq;
using PacmanGame.Business.UserInterface;
using PacmanGame.Data.Enums;
using PacmanGame.UserInterface;

namespace PacmanGame {
    public class Game : IGame {
        public bool HasWon { get; set; } = false;
        public int PelletCount { get; set; }
        public GameBoard Board { get; private set; }
        public Pacman Pacman { get; set; }
        private Direction CurrentDirection { get; set; }
        private int CurrentVelocity { get; set; }

        private IUserInterface UI { get; set; }

        public Game(GameBoard board, IUserInterface ui) {
            Board = board;
            UI = ui;
            Pacman = new Pacman(board.PacStartX, board.PacStartY, board.PacStartDirection, ui);
            CurrentDirection = board.PacStartDirection;
            CurrentVelocity = 1;
        }

        public void CheckWin() {
            if (PelletCount == 0) {
                HasWon = true;
            }
        }

        private void ResetPacman() {
            Pacman.X = Board.PacStartX;
            Pacman.Y = Board.PacStartY;
            Pacman.currentDirection = Board.PacStartDirection;
        }

        public void InitBoard(GameBoard board) {
            Board = board;
            ResetPacman();
        }

        public void TakeInput(Direction direction) {
            if (CheckSpot(direction) == TileType.Wall) return;
            CurrentDirection = direction;
            CurrentVelocity = 1;
        }

        public void Update() {
            if (CheckSpot(CurrentDirection) == TileType.Wall) {
                CurrentVelocity = 0;
            }
            Pacman.Update(CurrentDirection, CurrentVelocity);
            Pacman.Move();
        }

        private TileType CheckSpot(Direction direction) {
            var potentialPac = new Pacman(Pacman.X, Pacman.Y, Pacman.currentDirection, Pacman.UI);
            potentialPac.Update(direction, 1);
            potentialPac.Move();
            return Board.Data.Find(m => m.X == potentialPac.X && m.Y == potentialPac.Y).Type;
        }
    }
}