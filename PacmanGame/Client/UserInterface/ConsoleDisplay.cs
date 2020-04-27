using System;
using PacmanGame.Data;
using PacmanGame.Data.Enums;


namespace PacmanGame.Client.UserInterface {
    public class ConsoleDisplay : IDisplay {
        public void WriteBoard(GameBoard board) {
            Console.CursorVisible = false;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            for (int i = 1; i <= board.Height; i++) {
                for (int j = 1; j <= board.Width; j++) {
                    var currentTile = board.Data.Find(m => m.X == j && m.Y == i);
                    Console.SetCursorPosition((j*3)-2, i);
                    if (currentTile.Display == SpriteData.TileWall) {
                        Console.Write(currentTile.Display);
                    }
                }
            }
        }

        public void UpdatePacmanDisplay(Direction direction, Pacman pacman) {
            pacman.Display = direction switch {
                Direction.Up => SpriteData.PacUp,
                Direction.Down => SpriteData.PacDown,
                Direction.Left => SpriteData.PacLeft,
                Direction.Right => SpriteData.PacRight,
                _ => throw new Exception()
            };
        }

        public void DisplayPellets(Game game) {
            foreach (var pellet in game.ActivePellets) {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.SetCursorPosition(pellet.X*3-2, pellet.Y);
                Console.Write(pellet.Display);
            }
        }
    }
}