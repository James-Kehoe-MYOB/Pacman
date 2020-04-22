namespace PacmanGame {
    public class Tile {

        public const char Wall = 'W';
        public const char Empty = '\u25A9';
        
        public bool IsWall { get; set; }
        public int X { get; set; }
        public int Y { get; set; }

        public char Display { get; private set; }

        public Tile(int x, int y, bool isWall) {
            X = x;
            Y = y;
            IsWall = isWall;

            Display = isWall ? Wall : Empty;
        }
        
        
        
    }
}