using PacmanGame.Data.LevelData;

namespace PacmanGame.DataAccess.BoardLayoutConverter {
    public interface IBoardLayoutConverter {
        public LevelLayout Convert(int height, int width, string rawData);
    }
}