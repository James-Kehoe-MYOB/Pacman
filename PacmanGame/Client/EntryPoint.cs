using System;
using System.Collections.Generic;
using PacmanGame.Client.UserInterface;
using PacmanGame.Data.Enums;

namespace PacmanGame.Client {
    class EntryPoint {
        static void Main(string[] args) {
            var converter = new BinaryToBoardDataConverter();
            
            var pacman = new Pacman(2, 2, Direction.Right, new KeyInput(), new ConsoleDisplay());

            var rawData = "1111111111111111111" +
                          "1000000001000000001" +
                          "1011011101011101101" +
                          "1000000000000000001" +
                          "1011010111110101101" +
                          "1000010001000100001" +
                          "1111011101011101111" +
                          "1111010000000101111" +
                          "1111010110110101111" +
                          "0000000100010000000" +
                          "1111010111110101111" +
                          "1111010000000101111" +
                          "1111010111110101111" +
                          "1000000001000000001" +
                          "1011011101011101101" +
                          "1001000000000001001" +
                          "1101010111110101011" +
                          "1000010001000100001" +
                          "1011111101011111101" +
                          "1000000000000000001" +
                          "1111111111111111111";

            var data = converter.Convert(21, 19, rawData);
            var board = new GameBoard(19, 21, pacman.X, pacman.Y, pacman.currentDirection, data);
            var game = new Game(board, new KeyInput(), new ConsoleDisplay());
            
            game.Run();
            game.LoadBoard(board);
            game.Run();
        }
    }
}