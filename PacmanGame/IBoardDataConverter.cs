namespace PacmanGame {
    public interface IBoardDataConverter {
        public BoardData Convert(int height, int width, string rawData);
    }
}