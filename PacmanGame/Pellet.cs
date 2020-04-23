using System;

namespace PacmanGame {
    public class Pellet {

        public const char Default = '*';
        public const char Eaten = ' ';

        public int X { get; private set; }
        public int Y { get; private set; }

        public bool IsEaten { get; set; }

        public char Display { get; set; }

        public Pellet(int x, int y) {
            X = x;
            Y = y;
            IsEaten = false;
            UpdateDisplay();
        }

        public void UpdateDisplay() {
            Display = IsEaten switch {
                true => Eaten,
                false => Default
            };
        }
        
    }
}