using System;
using System.Collections.Generic;
using PacmanGame.Business.Characters;
using PacmanGame.Business.Game;
using PacmanGame.Business.GameObjects;
using PacmanGame.Data;
using PacmanGame.Data.Board_Data;
using PacmanGame.Data.Enums;


namespace PacmanGame.Client.UserInterface {
    public class ConsoleDisplay : IDisplay {
        public void WriteMenu() {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.SetCursorPosition(0,3);
            Console.WriteLine(SpriteData.splashScreen);
            Console.SetCursorPosition(19,10);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Press any key to start!");
            Console.ReadKey();
            Console.Clear();
        }

        public void WriteLives(int lives) {
            Console.SetCursorPosition(25, 10);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write($"{SpriteData.PacRight}");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write($"\u00D7 {lives}");
            System.Threading.Thread.Sleep(1500);
        }

        public void WriteGameObjects(Pacman pacman, List<Pellet> pellets, List<Ghost> ghosts) {
            DisplayPellets(pellets);
            WriteSprite(pacman);
            foreach (var ghost in ghosts) {
                WriteSprite(ghost);
            }
        }

        public void WriteBoard(Board board) {
            Console.CursorVisible = false;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            for (int i = 1; i <= board.Height; i++) {
                for (int j = 1; j <= board.Width; j++) {
                    var currentTile = board.Layout.Find(m => m.X == j && m.Y == i);
                    Console.SetCursorPosition((j*3)-2, i);
                    if (currentTile.Display == SpriteData.TileWall) {
                        Console.Write(currentTile.Display);
                    }
                }
            }
            Console.SetCursorPosition(1, board.Height+1);
            Console.ForegroundColor = ConsoleColor.White;
        }

        public string UpdatePacmanSprite(Direction direction) {
            var sprite = direction switch {
                Direction.Up => SpriteData.PacUp,
                Direction.Down => SpriteData.PacDown,
                Direction.Left => SpriteData.PacLeft,
                Direction.Right => SpriteData.PacRight,
                _ => throw new Exception()
            };
            return sprite;
        }

        public void DisplayPellets(List<Pellet> activePellets) {
            foreach (var pellet in activePellets) {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.SetCursorPosition(pellet.X*3-2, pellet.Y);
                Console.Write(pellet.Sprite);
            }
        }

        public void WriteSprite(Character character) {
            Console.SetCursorPosition(character.X*3-2, character.Y);
            Console.ForegroundColor = character.Colour;
            Console.WriteLine(character.Sprite);
        }

        public void ClearTileDisplay(int x, int y, Board board) {
            Console.SetCursorPosition(x*3-2, y);
            var tile = board.Layout.Find(m => m.X == x && m.Y == y);
            Console.Write(tile.Display);
        }
    }
}