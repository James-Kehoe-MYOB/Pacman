namespace PacmanGame {
    public class ConsoleUI : IUserInterface {
        public Direction TakeInput() {
            return Direction.Right;
        }
    }
}