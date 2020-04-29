using System;
using PacmanGame.Data.Enums;

namespace PacmanGame.Business.Characters {
    public interface ICharacter {
        public int X { get; set; }
        public int Y { get; set; }
        public int Velocity { get; }
        public Direction Direction { get; }
        public ConsoleColor Colour { get; }
        public string Sprite { get; }


    }
}