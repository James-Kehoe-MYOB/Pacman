using System;
using PacmanGame.Data.Enums;

namespace PacmanGame.Business.GhostLogic {
    public class RandomGhostLogic : IGhostLogic {
        public Direction ChooseDirection() {
            
            var random = new Random();
            var direction = random.Next(1, 5);
            Direction dir;
            dir = direction switch {
                1 => Direction.Down,
                2 => Direction.Up,
                3 => Direction.Left,
                4 => Direction.Right,
                _ => throw new Exception()
            };
            return dir;
            
        }
    }
}