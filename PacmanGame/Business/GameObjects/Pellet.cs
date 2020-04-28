using PacmanGame.Data;

namespace PacmanGame.Business.GameObjects {
    public class Pellet {

        public string Sprite = SpriteData.Pellet;

        public int X { get; private set; }
        public int Y { get; private set; }

        public Pellet(Coords coords) {
            X = coords.x;
            Y = coords.y;

        }

    }
}