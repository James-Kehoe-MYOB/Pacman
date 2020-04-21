using System;

namespace PacmanGame {
    public class Pacman {

        public const char Up = '\u15E2';
        public const char Down = '\u15E3';
        public const char Left = '\u15E4';
        public const char Right = '\u15E7';
        
        public int X { get; private set; }
        public int Y { get; private set; }
        private Direction StartingDirection { get; set; }
        public char Display { get; set; }
        
        public Direction currentDirection;

        private int Velocity { get; set; } = 1;

        private IUserInterface UI { get; set; }

        public Pacman(int x, int y, Direction startingDirection, IUserInterface UI) {
            X = x;
            Y = y;
            StartingDirection = startingDirection;
            this.UI = UI;
            
            AssignDisplay(startingDirection);
        }

        private void AssignDisplay(Direction direction) {
            currentDirection = direction;
            
            Display = direction switch {
                Direction.Up => Up,
                Direction.Down => Down,
                Direction.Left => Left,
                Direction.Right => Right,
                _ => throw new Exception()
            };
        }

        public void Update(Direction direction, int velocity) {
            currentDirection = direction;
            AssignDisplay(currentDirection);
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