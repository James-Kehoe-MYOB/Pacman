using System;
using PacmanGame.Business.GhostLogic;
using PacmanGame.Data;
using PacmanGame.Data.Enums;

namespace PacmanGame.Business.Characters {
    public class Ghost : ICharacter {

        public readonly IGhostLogic Logic;
        public int X { get; set; }
        public int Y { get; set; }
        public int Velocity { get; set; }
        public Direction Direction { get; set; }
        public ConsoleColor Colour { get; set; } = ConsoleColor.Green;
        public string Sprite { get; } = SpriteData.Ghost;

        public Ghost(int x, int y, IGhostLogic logic) {
            X = x;
            Y = y;
            Logic = logic;
            Direction = ChooseDirection();
        }

        public Direction ChooseDirection() {
            return Logic.ChooseDirection();
        }
    }
}