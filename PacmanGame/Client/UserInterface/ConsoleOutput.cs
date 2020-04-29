using System;
using System.Collections.Generic;
using PacmanGame.Business.Characters;
using PacmanGame.Business.GameObjects;
using PacmanGame.Data;
using PacmanGame.Data.Enums;
using PacmanGame.Data.LevelData;


namespace PacmanGame.Client.UserInterface {
    public class ConsoleOutput : IOutput {

        public void WriteLine(string message) {
            Console.WriteLine(message);
        }
        public void Pause(int milliseconds) {
            System.Threading.Thread.Sleep(milliseconds);
        }

        public void WriteMenu() {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.SetCursorPosition(0,3);
            Console.WriteLine(SpriteData.SplashScreen);
            Console.SetCursorPosition(19,10);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Press any key to start!");
            Console.ReadKey();
            Console.Clear();
        }

        public void WriteGameOver() {
            Console.Clear();
            Console.SetCursorPosition(19,10);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Game Over! Thanks for Playing");
        }

        public void WriteLives(int lives) {
            Console.Clear();
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

        public void WriteBoard(Level level) {
            Console.CursorVisible = false;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            for (int i = 1; i <= level.Height; i++) {
                for (int j = 1; j <= level.Width; j++) {
                    var currentTile = level.Layout.Find(m => m.X == j && m.Y == i);
                    Console.SetCursorPosition((j*3)-2, i);
                    if (currentTile.Display == SpriteData.TileWall) {
                        Console.Write(currentTile.Display);
                    }
                }
            }
            Console.SetCursorPosition(1, level.Height+1);
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

        private void DisplayPellets(List<Pellet> activePellets) {
            foreach (var pellet in activePellets) {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.SetCursorPosition(pellet.X*3-2, pellet.Y);
                Console.Write(pellet.Sprite);
            }
        }

        public void WriteSprite(ICharacter character) {
            Console.SetCursorPosition(character.X*3-2, character.Y);
            Console.ForegroundColor = character.Colour;
            Console.WriteLine(character.Sprite);
        }

        public void ClearTileDisplay(int x, int y, Level level) {
            Console.SetCursorPosition(x*3-2, y);
            var tile = level.Layout.Find(m => m.X == x && m.Y == y);
            Console.Write(tile.Display);
        }
    }
}