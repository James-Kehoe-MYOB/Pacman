using System;
using System.Collections.Generic;
using PacmanGame.Data.Enums;
using PacmanGame.UserInterface;

namespace PacmanGame.Client {
    class EntryPoint {
        static void Main(string[] args) {
            var pacman = new Pacman(2, 2, Direction.Right, new ConsoleUI());
            
            var data = new List<Tile> {
                new Tile(1, 1, TileType.Wall), new Tile(2, 1, TileType.Wall), new Tile(3, 1, TileType.Wall), new Tile(4, 1, TileType.Wall), new Tile(5, 1, TileType.Wall),
                new Tile(1, 2, TileType.Wall), new Tile(2, 2, TileType.Empty), new Tile(3, 2, TileType.Empty), new Tile(4, 2, TileType.Empty), new Tile(5, 2, TileType.Wall),
                new Tile(1, 3, TileType.Wall), new Tile(2, 3, TileType.Empty), new Tile(3, 3, TileType.Wall), new Tile(4, 3, TileType.Empty), new Tile(5, 3, TileType.Wall),
                new Tile(1, 4, TileType.Wall), new Tile(2, 4, TileType.Empty), new Tile(3, 4, TileType.Empty), new Tile(4, 4, TileType.Empty), new Tile(5, 4, TileType.Wall),
                new Tile(1, 5, TileType.Wall), new Tile(2, 5, TileType.Wall), new Tile(3, 5, TileType.Wall), new Tile(4, 5, TileType.Wall), new Tile(5, 5, TileType.Wall),
            };
            
            var game = new Game(new GameBoard(5,5, pacman.X, pacman.Y, pacman.currentDirection, data), new ConsoleUI());
            Console.CursorVisible = false;
            Console.Clear();
            for (int i = 1; i <= 5; i++) {
                for (int j = 1; j <= 5; j++) {
                    Console.SetCursorPosition(i, j);
                    Console.Write(game.Board.Data.Find(m => m.X == i && m.Y == j).Display);
                }
            }
            
            Console.SetCursorPosition(game.Pacman.X, game.Pacman.Y);
            Console.Write(game.Pacman.Display);
            System.Threading.Thread.Sleep(200);
            var random = new Random();
            while (true) {
                Move(game);
                while (game.Pacman.Velocity == 0) {
                    var dir = random.Next(1, 5);
                    switch (dir) {
                        case 1:
                            game.TakeInput(Direction.Right);
                            Move(game);
                            break;
                        case 2:
                            game.TakeInput(Direction.Down);
                            Move(game);
                            break;
                        case 3:
                            game.TakeInput(Direction.Left);
                            Move(game);
                            break;
                        case 4:
                            game.TakeInput(Direction.Up);
                            Move(game);
                            break;
                    }
                }
            }
        }

        private static void Move(Game game) {
            Console.SetCursorPosition(game.Pacman.X, game.Pacman.Y);
            Console.Write(" ");
            game.Update();
            Console.SetCursorPosition(game.Pacman.X, game.Pacman.Y);
            Console.Write(game.Pacman.Display);
            System.Threading.Thread.Sleep(200);
        }
    }
}