using PacmanGame.Business.UserInterface;
using PacmanGame.Data.Enums;

namespace PacmanGame.UserInterface {
    public class ConsoleUI : IUserInterface {
        public Direction TakeInput() {
            return Direction.Right;
        }
    }
}