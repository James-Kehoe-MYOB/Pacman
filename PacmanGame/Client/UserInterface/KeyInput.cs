using System;
using PacmanGame.Data.Enums;

namespace PacmanGame.Client.UserInterface {
    public class KeyInput : IInput {
        public Direction TakeInput(Pacman pacman) {
            var input = Console.ReadKey(true).Key;
            if (CheckValidInput(input)) {
                return input switch {
                    ConsoleKey.LeftArrow => Direction.Left,
                    ConsoleKey.RightArrow => Direction.Right,
                    ConsoleKey.UpArrow => Direction.Up,
                    ConsoleKey.DownArrow => Direction.Down,
                    _ => throw new Exception()
                };
            }
            return pacman.currentDirection;
        }

        private bool CheckValidInput(ConsoleKey input) {
            return input == ConsoleKey.LeftArrow
                   || input == ConsoleKey.RightArrow
                   || input == ConsoleKey.UpArrow
                   || input == ConsoleKey.DownArrow;
        }
    }
}