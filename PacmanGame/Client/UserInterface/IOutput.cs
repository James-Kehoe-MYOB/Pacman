using System.Collections.Generic;
using PacmanGame.Business.Characters;
using PacmanGame.Business.GameObjects;
using PacmanGame.Data.Enums;
using PacmanGame.Data.LevelData;

namespace PacmanGame.Client.UserInterface {
    public interface IOutput {

        void WriteLine(string message);
        void Pause(int milliseconds);

        void WriteMenu();

        void WriteGameOver();

        void WriteLives(int lives);
        
        void WriteGameObjects(Pacman pacman, List<Pellet> pellets, List<Ghost> ghosts);

        void WriteBoard(Level level);

        string UpdatePacmanSprite(Direction direction);

        void WriteSprite(ICharacter character);

        void ClearTileDisplay(int x, int y, Level level);

    }
}