using System.Collections.Generic;
using PacmanGame.Business.Characters;
using PacmanGame.Data.Enums;

namespace PacmanGame.Data.Maps {
    public class MapData {
        public MapData(List<LevelSetName> sets, int height, int width, int pacStartX, int pacStartY, Direction pacStartDirection, List<Ghost> ghosts, string data) {
            Sets = sets;
            Height = height;
            Width = width;
            PacStartX = pacStartX;
            PacStartY = pacStartY;
            PacStartDirection = pacStartDirection;
            Ghosts = ghosts;
            Data = data;
        }

        public List<LevelSetName> Sets { get; private set; }
        public int Height { get; set; }
        public int Width { get; set; }
        public int PacStartX { get; set; }
        public int PacStartY { get; set; }
        public Direction PacStartDirection { get; set; }
        public List<Ghost> Ghosts { get; set; }
        public string Data { get; set; }
        
        
    }
}