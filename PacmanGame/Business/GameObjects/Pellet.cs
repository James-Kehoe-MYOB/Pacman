using PacmanGame.Data;

namespace PacmanGame.Business.GameObjects {
    public class Pellet {

        public string Sprite = SpriteData.Pellet;

        public int X { get; private set; }
        public int Y { get; private set; }

        public Pellet(int x, int y) {
            X = x;
            Y = y;

        }

    }
}