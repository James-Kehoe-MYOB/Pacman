using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using PacmanGame;
using PacmanGame.Data.Enums;
using Xunit;

namespace PacmanGameTests {
    public class ConverterTests {

        [Fact(DisplayName = "Inputting Raw Data returns BoardData Object")]

        public void InputtingRawDataReturnsBoardDataObject() {
            var rawData = "01" +
                          "10";
            var height = 2;
            var width = 2;
            
            var converter = new BinaryToBoardDataConverter();

            var expectedData = new BoardData {
                new Tile(1, 1, TileState.Empty),
                new Tile(2, 1, TileState.Wall),
                new Tile(1, 2, TileState.Wall),
                new Tile(2, 2, TileState.Empty)
            };

            expectedData.Append(new Tile(1, 1, TileState.Empty));

            var boardData = converter.Convert(height, width, rawData);

            for (int i = 0; i < expectedData.Count; i++) {
                Assert.Equal(expectedData[i].X, boardData[i].X);
                Assert.Equal(expectedData[i].Y, boardData[i].Y);
                Assert.Equal(expectedData[i].State, boardData[i].State);
            }
        }
    }
}