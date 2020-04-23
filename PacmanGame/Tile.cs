using System;
using System.Collections.Generic;

namespace PacmanGame {
    public class Tile {

        public static readonly Dictionary<TileState, char> TileSpriteMap = new Dictionary<TileState, char> {
            {TileState.Empty, ' '},
            {TileState.Wall, '\u00D7'}
        };

        public TileState State { get; set; }
        public int X { get; private set; }
        public int Y { get; private set; }

        public char Display { get; private set; }

        public Tile(int x, int y, TileState state) {
            X = x;
            Y = y;
            State = state;

            if (TileSpriteMap.TryGetValue(state, out var display)) {
                Display = display;
            }
            else {
                throw new Exception();
            }
        }
    }
}