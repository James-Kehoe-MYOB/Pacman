using System;
using PacmanGame.Business.Characters;
using PacmanGame.Data.Enums;

namespace PacmanGame.Client.UserInterface {
    public class KeyInput : IInput {
        public bool KeyAvailable() {
            return Console.KeyAvailable;
        }

        public Direction TakeInput(Pacman pacman) {
            var input = Console.ReadKey(true).Key;
            if (CheckValidInput(input)) {
                return input switch {
                    ConsoleKey.RightArrow => Direction.Right,
                    ConsoleKey.LeftArrow => Direction.Left,
                    ConsoleKey.UpArrow => Direction.Up,
                    ConsoleKey.DownArrow => Direction.Down,
                    _ => pacman.Direction
                };
            }

            return pacman.Direction;
        }

        public static bool CheckValidInput(ConsoleKey input) {
            return input == ConsoleKey.LeftArrow
                   || input == ConsoleKey.RightArrow
                   || input == ConsoleKey.UpArrow
                   || input == ConsoleKey.DownArrow;
        }
    }
}