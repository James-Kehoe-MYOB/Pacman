using PacmanGame.Data.Board;

namespace PacmanGame.DataAccess.BoardLayoutConverter {
    public interface IBoardLayoutConverter {
        public BoardLayout Convert(int height, int width, string rawData);
    }
}