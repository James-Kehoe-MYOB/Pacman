using PacmanGame.Data.Board_Data;

namespace PacmanGame.DataAccess.BoardLayoutConverter {
    public interface IBoardLayoutConverter {
        public BoardLayout Convert(int height, int width, string rawData);
    }
}