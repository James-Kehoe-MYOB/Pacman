using PacmanGame;
using Xunit;

namespace PacmanGameTests {
    public class TileTests {
        [Theory(DisplayName = "Tile Displays Correctly According to TileType")]
        [InlineData(true, Tile.Wall)]
        [InlineData(false, Tile.Empty)]

        public void TileDisplaysCorrectlyAccordingToTileType(bool isWall, char display) {
            var tile = new Tile(1, 1, isWall);
            
            Assert.Equal(display, tile.Display);
        }
    }
}