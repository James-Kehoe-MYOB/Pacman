using System;
using PacmanGame.Business.GameObjects;
using PacmanGame.Data.Board;
using PacmanGame.Data.Enums;

namespace PacmanGame.DataAccess.BoardLayoutConverter {
    public class BinaryToBoardLayoutConverter : IBoardLayoutConverter {

        public BoardLayout Convert(int height, int width, string rawData) {
            var returnData = new BoardLayout();

            var x = 1;
            var y = 1;
            foreach (var c in rawData) {
                var isWall = c switch {
                    '0' => TileState.Empty,
                    '1' => TileState.Wall,
                    _ => throw new InvalidBoardDataFormatException()
                };
                returnData.Add(new Tile(x, y, isWall));
                if (x < width) {
                    x++;
                } else if (x == width) {
                    x = 1;
                    y++;
                }
            }

            if (returnData.Count != height * width) {
                throw new InsufficientBoardDataException();
            }
            
            return returnData;
        }
    }

    public class InsufficientBoardDataException : Exception {
    }

    public class InvalidBoardDataFormatException : Exception {
    }
}