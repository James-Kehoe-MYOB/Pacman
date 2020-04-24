using System;
using PacmanGame.Data.Enums;


namespace PacmanGame.Client.UserInterface {
    public class ConsoleDisplay : IDisplay {
        public void WriteBoard(GameBoard board) {
            Console.CursorVisible = false;
            Console.Clear();
            for (int i = 1; i <= board.Height; i++) {
                for (int j = 1; j <= board.Width; j++) {
                    Console.SetCursorPosition(j, i);
                    Console.Write(board.Data.Find(m => m.X == j && m.Y == i).Display);
                }
            }
        }

        public void UpdatePacmanDisplay(Direction direction, Pacman pacman) {
            pacman.Display = direction switch {
                Direction.Up => Pacman.Up,
                Direction.Down => Pacman.Down,
                Direction.Left => Pacman.Left,
                Direction.Right => Pacman.Right,
                _ => throw new Exception()
            };
        }

        public void DisplayPellets(Game game) {
            foreach (var pellet in game.ActivePellets) {
                Console.SetCursorPosition(pellet.X, pellet.Y);
                Console.Write(pellet.Display);
            }
        }
    }
}