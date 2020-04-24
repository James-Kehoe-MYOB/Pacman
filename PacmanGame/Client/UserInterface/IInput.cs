using PacmanGame.Data.Enums;

namespace PacmanGame.Client.UserInterface {
    public interface IInput {

        Direction TakeInput(Pacman pacman);

    }
}