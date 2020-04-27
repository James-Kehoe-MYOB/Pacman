using System;
using System.Collections.Generic;
using PacmanGame.Data;
using PacmanGame.Data.Enums;

namespace PacmanGame {
    public class Tile {

        public static readonly Dictionary<TileState, string> TileSpriteMap = new Dictionary<TileState, string> {
            {TileState.Empty, "   "},
            {TileState.Wall, "\u2588\u2588\u2588"}
        };

        public TileState State { get; set; }
        public int X { get; private set; }
        public int Y { get; private set; }
        public string Display { get; private set; }

        public Tile(int x, int y, TileState state) {
            X = x;
            Y = y;
            State = state;

            Display = state switch {
                TileState.Empty => SpriteData.TileEmpty,
                TileState.Wall => SpriteData.TileWall,
                _ => throw new Exception()
            };
        }
    }
}