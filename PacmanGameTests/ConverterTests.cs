using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using PacmanGame;
using PacmanGame.Business.GameObjects;
using PacmanGame.Data.Enums;
using PacmanGame.Data.Exceptions;
using PacmanGame.Data.LevelData;
using PacmanGame.DataAccess.BoardLayoutConverter;
using Xunit;

namespace PacmanGameTests {
    public class ConverterTests {

        [Fact(DisplayName = "Inputting Raw Layout returns LevelLayout Object")]

        public void InputtingRawDataReturnsBoardDataObject() {
            var rawData = "01" +
                          "10";
            var height = 2;
            var width = 2;
            
            var converter = new BinaryToBoardLayoutConverter();

            var expectedData = new LevelLayout {
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

        [Theory(DisplayName = "Attempting to Fill a GameBoard With an Invalid Data Format Throws an Exception")]
        [InlineData("_INVALID_")]
        [InlineData("123456789")]
        public void AttemptingToFillAGameBoardWithAnInvalidDataFormatThrowsAnException(string data) {

            var height = 1;
            var width = 9;
            
            var converter = new BinaryToBoardLayoutConverter();

            Assert.Throws<InvalidLevelDataFormatException>(() => converter.Convert(height, width, data));
        }
        
        [Fact(DisplayName = "Attempting to Fill a GameBoard With Insufficient Data Throws an Exception")]

        public void AttemptingToFillAGameBoardWithInsufficientDataThrowsAnException() {
            var insufficientData = "010";
            var height = 10;
            var width = 10;
            
            var converter = new BinaryToBoardLayoutConverter();

            Assert.Throws<InsufficientLevelDataException>(() => converter.Convert(height, width, insufficientData));
        }

    }
}