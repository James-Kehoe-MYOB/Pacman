using System;
using PacmanGame.Business.Game;
using PacmanGame.Data.Enums;

namespace PacmanGame {
    public class MovementHandler {
        private Game _game;


        public MovementHandler(Game game) {
            _game = game;
        }

        // public void ChooseDirection() {
        //     Console.SetCursorPosition(_game.Pacman.X*3-2, _game.Pacman.Y);
        //     Console.Write("   ");
        //     switch (_game.Pacman.Direction) {
        //         case Direction.Up:
        //             if (_game.Pacman.Y == 1 && _game.CurrentVelocity == 1) {
        //                 pacman.Y = Board.Height;
        //             }
        //             else {
        //                 pacman.Y -= CurrentVelocity;
        //             }
        //             break;
        //         case Direction.Down:
        //             if (pacman.Y == Board.Height && CurrentVelocity == 1) {
        //                 pacman.Y = 1;
        //             }
        //             else {
        //                 pacman.Y += CurrentVelocity;
        //             }
        //             break;
        //         case Direction.Left:
        //             if (pacman.X == 1 && CurrentVelocity == 1) {
        //                 pacman.X = Board.Width;
        //             }
        //             else {
        //                 pacman.X -= CurrentVelocity;
        //             }
        //             break;
        //         case Direction.Right:
        //             if (pacman.X == Board.Width && CurrentVelocity == 1) {
        //                 pacman.X = 1;
        //             }
        //             else {
        //                 pacman.X += CurrentVelocity;
        //             }
        //             break;
        //         default:
        //             throw new Exception();
        //     }
        //     DisplayHandler.WritePacman(Pacman);
        // }

        public void MoveGhost() {
            
        }
    }
}