using System;
using PacmanGame.Client.UserInterface;
using PacmanGame.Data.Enums;

namespace PacmanGame.Business.Characters {
    public class Pacman : ICharacter {

        public int X { get; set; }
        public int Y { get; set; }
        public Direction Direction { get; set; }
        public ConsoleColor Colour { get; } = ConsoleColor.Yellow;
        public string Sprite { get; set; }
        public int Velocity { get; set; } = 1;
        private IOutput Output { get; }

        public Pacman(int x, int y, Direction startingDirection, IOutput output) {
            X = x;
            Y = y;
            Output = output;
            Direction = startingDirection;
            Sprite = Output.UpdatePacmanSprite(startingDirection);
        }

        public void Update(Direction direction, int velocity) {
            Direction = direction;
            Sprite = Output.UpdatePacmanSprite(direction);
            Velocity = velocity;
        }
    }
}