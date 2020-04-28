using System;
using System.Collections.Generic;
using PacmanGame.Business.Characters;
using PacmanGame.Business.GameObjects;
using PacmanGame.Data.Board;
using PacmanGame.Data.Enums;

namespace PacmanGame.Client.UserInterface {
    public interface IDisplay {

        public void WriteMenu();

        public void WriteBoard(Board board);

        public string UpdatePacmanSprite(Direction direction);

        public void DisplayPellets(List<Pellet> activePellets, List<Ghost> ghosts);

        public void WritePacman(Pacman pacman);
        
        public void WriteSprite(Character character);

        public void ResetTileDisplay(int x, int y, Board board);

    }
}