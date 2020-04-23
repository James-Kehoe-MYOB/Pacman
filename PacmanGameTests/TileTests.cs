using System.Linq;
using PacmanGame;
using Xunit;

namespace PacmanGameTests {
    public class TileTests {
        [Theory(DisplayName = "Tile Displays Correctly According to TileType")]
        [InlineData(TileType.Wall)]
        [InlineData(TileType.Empty)]

        public void TileDisplaysCorrectlyAccordingToTileType(TileType type) {
            var tile = new Tile(1, 1, type);
            
            Assert.Equal(Tile.TileSpriteMap[type], tile.Display);
        }
    }
}