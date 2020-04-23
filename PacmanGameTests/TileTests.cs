using System.Linq;
using PacmanGame;
using Xunit;

namespace PacmanGameTests {
    public class TileTests {
        [Theory(DisplayName = "Tile Displays Correctly According to TileState")]
        [InlineData(TileState.Wall)]
        [InlineData(TileState.Empty)]

        public void TileDisplaysCorrectlyAccordingToTileType(TileState state) {
            var tile = new Tile(1, 1, state);
            
            Assert.Equal(Tile.TileSpriteMap[state], tile.Display);
        }
    }
}