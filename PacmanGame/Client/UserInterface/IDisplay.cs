using System;
using PacmanGame.Data.Enums;

namespace PacmanGame.Client.UserInterface {
    public interface IDisplay {

        public void WriteBoard(GameBoard board);

        public void UpdatePacmanDisplay(Direction direction, Pacman pacman);

        public void DisplayPellets(Game game);

    }
}