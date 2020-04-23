using System;
using System.Collections.Generic;

namespace PacmanGame {
    public class Tile {

        public static readonly Dictionary<TileType, char> TileSpriteMap = new Dictionary<TileType, char> {
            {TileType.Empty, ' '},
            {TileType.Pellet, '*'},
            {TileType.Wall, '\u00D7'}
        };

        public TileType Type { get; set; }
        public int X { get; private set; }
        public int Y { get; private set; }

        public char Display { get; private set; }

        public Tile(int x, int y, TileType type) {
            X = x;
            Y = y;
            Type = type;

            if (TileSpriteMap.TryGetValue(type, out var display)) {
                Display = display;
            }
            else {
                throw new Exception();
            }
        }
    }
}