using PacmanGame;
using PacmanGame.Business.GameObjects;
using PacmanGame.Data;
using PacmanGame.Data.Enums;
using Xunit;

namespace PacmanGameTests {
    public class TileTests {
        [Theory(DisplayName = "Tile Displays Correctly According to TileState")]
        [InlineData(TileState.Wall, SpriteData.TileWall)]
        [InlineData(TileState.Empty, SpriteData.TileEmpty)]

        public void TileDisplaysCorrectlyAccordingToTileState(TileState state, string display) {
            var tile = new Tile(1, 1, state);
            
            Assert.Equal(display, tile.Display);
        }
    }
}