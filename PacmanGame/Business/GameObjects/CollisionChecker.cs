using System;
using PacmanGame.Business.Characters;
using PacmanGame.Data.Enums;

namespace PacmanGame.Business.GameObjects {
    public class Collision : ICharacter {
        public int X { get; set; }
        public int Y { get; set; }
        public int Velocity { get; set; }
        public Direction Direction { get; set; }
        public ConsoleColor Colour { get; set; }
        public string Sprite { get; set; }

        public Collision(ICharacter character) {
            X = character.X;
            Y = character.Y;
            Velocity = 1;
            Direction = character.Direction;
        }
    }
}