using System;
using PacmanGame.Data.Enums;

namespace PacmanGame.Business.Characters {
    public interface Character {
        public int X { get; set; }
        public int Y { get; set; }
        public int Velocity { get; set; }
        public Direction Direction { get; set; }
        public ConsoleColor Colour { get; set; }

        public string Sprite { get; set; }


    }
}