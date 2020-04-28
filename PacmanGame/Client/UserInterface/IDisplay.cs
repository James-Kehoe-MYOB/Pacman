using System;
using System.Collections.Generic;
using PacmanGame.Business.Characters;
using PacmanGame.Business.Game;
using PacmanGame.Business.GameObjects;
using PacmanGame.Data.Board_Data;
using PacmanGame.Data.Enums;

namespace PacmanGame.Client.UserInterface {
    public interface IDisplay {

        public void WriteMenu();

        public void WriteLives(int lives);
        
        public void WriteGameObjects(Pacman pacman, List<Pellet> pellets, List<Ghost> ghosts);

        public void WriteBoard(Board board);

        public string UpdatePacmanSprite(Direction direction);

        public void DisplayPellets(List<Pellet> activePellets);

        public void WriteSprite(Character character);

        public void ClearTileDisplay(int x, int y, Board board);

    }
}