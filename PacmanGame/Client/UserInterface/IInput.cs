using PacmanGame.Data.Enums;

namespace PacmanGame.Client.UserInterface {
    public interface IInput {
        bool KeyAvailable();
        Direction TakeInput(Direction currentDirection);
    }
}