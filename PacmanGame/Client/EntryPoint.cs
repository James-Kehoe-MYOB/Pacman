using System;
using System.Collections.Generic;
using PacmanGame.Client.UserInterface;
using PacmanGame.Data.Enums;

namespace PacmanGame.Client {
    class EntryPoint {
        static void Main(string[] args) {
            var pacman = new Pacman(2, 2, Direction.Right, new KeyInput());
            
            var data = new List<Tile> {
                new Tile(1, 1, TileState.Wall), new Tile(2, 1, TileState.Wall), new Tile(3, 1, TileState.Empty), new Tile(4, 1, TileState.Wall), new Tile(5, 1, TileState.Wall),
                new Tile(1, 2, TileState.Wall), new Tile(2, 2, TileState.Empty), new Tile(3, 2, TileState.Empty), new Tile(4, 2, TileState.Empty), new Tile(5, 2, TileState.Wall),
                new Tile(1, 3, TileState.Empty), new Tile(2, 3, TileState.Empty), new Tile(3, 3, TileState.Wall), new Tile(4, 3, TileState.Empty), new Tile(5, 3, TileState.Empty),
                new Tile(1, 4, TileState.Wall), new Tile(2, 4, TileState.Empty), new Tile(3, 4, TileState.Empty), new Tile(4, 4, TileState.Empty), new Tile(5, 4, TileState.Wall),
                new Tile(1, 5, TileState.Wall), new Tile(2, 5, TileState.Wall), new Tile(3, 5, TileState.Empty), new Tile(4, 5, TileState.Wall), new Tile(5, 5, TileState.Wall),
            };
            var board = new GameBoard(5, 5, pacman.X, pacman.Y, pacman.currentDirection, data);
            var game = new Game(board, new KeyInput(), new ConsoleDisplay());
            foreach (var pellet in game.PelletList) {
                Console.SetCursorPosition(pellet.X, pellet.Y);
                Console.Write(pellet.Display);
            }
            Console.SetCursorPosition(game.Pacman.X, game.Pacman.Y);
            Console.Write(game.Pacman.Display);
            System.Threading.Thread.Sleep(500);
            game.Run();
        }
    }
}