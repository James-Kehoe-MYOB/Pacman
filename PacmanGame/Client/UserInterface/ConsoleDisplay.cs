using System;


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
    }
}