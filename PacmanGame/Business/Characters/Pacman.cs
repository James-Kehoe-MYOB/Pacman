using System;
using PacmanGame.Client.UserInterface;
using PacmanGame.Data.Enums;

namespace PacmanGame.Business.Characters {
    public class Pacman : Character {

        public int X { get; set; }
        public int Y { get; set; }
        public Direction Direction { get; set; }

        public ConsoleColor Colour { get; set; } = ConsoleColor.Yellow;
        public string Sprite { get; set; }
        public int Velocity { get; set; } = 1;

        public IDisplay Display { get; set; }

        public Pacman(Coords coords, Direction startingDirection, IDisplay display) {
            X = coords.x;
            Y = coords.y;
            Display = display;
            Direction = startingDirection;
            Sprite = Display.UpdatePacmanSprite(startingDirection);
        }

        public void Update(Direction direction, int velocity) {
            Direction = direction;
            Sprite = Display.UpdatePacmanSprite(direction);
            Velocity = velocity;
        }
    }
}