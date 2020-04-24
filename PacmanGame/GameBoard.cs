using System.Collections.Generic;
using PacmanGame.Data.Enums;

namespace PacmanGame {
    public class GameBoard {
        public int Width { get; set; }
        public int Height { get; set; }
        public int PacStartX { get; set; }
        public int PacStartY { get; set; }
        public Direction PacStartDirection { get; set; }
        public BoardData Data { get; set; }

        public GameBoard(int width, int height, int pacStartX, int pacStartY, Direction pacStartDirection, BoardData data) {
            Width = width;
            Height = height;
            PacStartX = pacStartX;
            PacStartY = pacStartY;
            PacStartDirection = pacStartDirection;
            Data = data;
        }
    }
}