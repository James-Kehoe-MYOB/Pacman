using System.Collections.Generic;
using PacmanGame.Business.Characters;
using PacmanGame.Data.Enums;

namespace PacmanGame.Data.LevelData {
    public class Level {
        public int Width { get; set; }
        public int Height { get; set; }
        public int PacStartX { get; set; }
        public int PacStartY { get; set; }
        public Direction PacStartDirection { get; set; }
        public List<Ghost> Ghosts { get; set; }
        public LevelLayout Layout { get; set; }

        public Level(int width, int height, int pacStartX, int pacStartY, Direction pacStartDirection, List<Ghost> ghosts, LevelLayout layout) {
            Width = width;
            Height = height;
            PacStartX = pacStartX;
            PacStartY = pacStartY;
            PacStartDirection = pacStartDirection;
            Ghosts = ghosts;
            Layout = layout;
        }
    }
}