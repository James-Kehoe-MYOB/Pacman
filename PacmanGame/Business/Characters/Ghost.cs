using System;
using PacmanGame.Business.GhostLogic;
using PacmanGame.Data;
using PacmanGame.Data.Enums;

namespace PacmanGame.Business.Characters {
    public class Ghost : Character {

        private IGhostLogic Logic;
        public int X { get; set; }
        public int Y { get; set; }
        public int Velocity { get; set; }
        public Direction Direction { get; set; }

        public ConsoleColor Colour { get; set; } = ConsoleColor.Green;
        public string Sprite { get; set; } = SpriteData.Ghost;

        public Ghost(Coords coords, Direction startingDirection, IGhostLogic logic) {
            X = coords.x;
            Y = coords.y;
            Logic = logic;
            Direction = startingDirection;
        }

        public Direction ChooseDirection() {
            return Logic.ChooseDirection();
        }
    }
}