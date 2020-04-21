using System;

namespace PacmanGame {
    class EntryPoint {
        static void Main(string[] args) {
            var pacman = new Pacman(2, 2, Direction.Right, new ConsoleUI());
            Console.CursorVisible = false;
            Console.Clear();
            Console.SetCursorPosition(pacman.X, pacman.Y);
            Console.Write(pacman.Display);
            System.Threading.Thread.Sleep(200);
            while (true) {
                pacman.Update(Direction.Right, 2);
                Move10(pacman);
                pacman.Update(Direction.Down, 1);
                Move10(pacman);
                pacman.Update(Direction.Left, 2);
                Move10(pacman);
                pacman.Update(Direction.Up, 1);
                Move10(pacman);
            }
        }

        private static void Move10(Pacman pacman) {
            for (int i = 0; i < 10; i++) {
                Console.SetCursorPosition(pacman.X, pacman.Y);
                Console.Write(" ");
                pacman.Move();
                Console.SetCursorPosition(pacman.X, pacman.Y);
                Console.Write(pacman.Display);
                System.Threading.Thread.Sleep(200);
            }
        }
    }
}