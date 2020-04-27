using System;
using PacmanGame.Client.UserInterface;
using PacmanGame.Data.Enums;

namespace PacmanGame {
    public class Pacman {

        public int X { get; set; }
        public int Y { get; set; }
        private Direction StartingDirection { get; set; }
        public string Display { get; set; }
        
        public Direction currentDirection;

        public int Velocity { get; set; } = 1;

        public IInput Input { get; set; }

        public IDisplay DisplayHandler { get; set; }

        public Pacman(int x, int y, Direction startingDirection, IInput input, IDisplay displayHandler) {
            X = x;
            Y = y;
            StartingDirection = startingDirection;
            Input = input;
            DisplayHandler = displayHandler;
            
            ChangeDirection(startingDirection);
        }

        private void ChangeDirection(Direction direction) {
            currentDirection = direction;
            DisplayHandler.UpdatePacmanDisplay(direction, this);
        }

        public void Update(Direction direction, int velocity) {
            currentDirection = direction;
            ChangeDirection(currentDirection);
            Velocity = velocity;
        }

        public void Move() {
            switch (currentDirection) {
                case Direction.Up:
                    Y -= Velocity;
                    break;
                case Direction.Down:
                    Y += Velocity;
                    break;
                case Direction.Left:
                    X -= Velocity;
                    break;
                case Direction.Right:
                    X += Velocity;
                    break;
                default:
                    throw new Exception();
            }
        }
    }
}