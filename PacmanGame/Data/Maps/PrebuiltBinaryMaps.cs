using System.Collections.Generic;
using PacmanGame.Business.Characters;
using PacmanGame.Business.GhostLogic;
using PacmanGame.Data.Board_Data;
using PacmanGame.Data.Enums;
using PacmanGame.DataAccess.BoardLayoutConverter;

namespace PacmanGame.Data.Maps {
    public class PrebuiltBinaryMaps {
        private const int ArcadeMapHeight = 21;
        private const int ArcadeMapWidth = 19;
        private const int ArcadeMapPacStartX = 10;
        private const int ArcadeMapPacStartY = 16;
        private const Direction ArcadeMapPacStartDirection = Direction.Right;

        private static List<Ghost> ArcadeMapGhosts = new List<Ghost> {
            new Ghost(new Coords {x = 5, y = 3}, Direction.Right, new RandomGhostLogic()),
            new Ghost(new Coords {x = 15, y = 3}, Direction.Left, new RandomGhostLogic())
        };

        private const string ArcadeMapData = "1111111111111111111" +
                                             "1000000001000000001" +
                                             "1011011101011101101" +
                                             "1000000000000000001" +
                                             "1011010111110101101" +
                                             "1000010001000100001" +
                                             "1111011101011101111" +
                                             "1111010000000101111" +
                                             "1111010110110101111" +
                                             "0000000100010000000" +
                                             "1111010111110101111" +
                                             "1111010000000101111" +
                                             "1111010111110101111" +
                                             "1000000001000000001" +
                                             "1011011101011101101" +
                                             "1001000000000001001" +
                                             "1101010111110101011" +
                                             "1000010001000100001" +
                                             "1011111101011111101" +
                                             "1000000000000000001" +
                                             "1111111111111111111";
        
        private static BinaryToBoardLayoutConverter _converter = new BinaryToBoardLayoutConverter();
        private static BoardLayout ArcadeMapLayout = _converter.Convert(ArcadeMapHeight, ArcadeMapWidth, ArcadeMapData);
        
        public Board ArcadeMapBoard = new Board(ArcadeMapWidth, ArcadeMapHeight, ArcadeMapPacStartX, ArcadeMapPacStartY, ArcadeMapPacStartDirection, ArcadeMapGhosts, ArcadeMapLayout);
        
        private const int AtariMapHeight = 17;
        private const int AtariMapWidth = 25;
        private const int AtariMapPacStartX = 13;
        private const int AtariMapPacStartY = 14;
        private const Direction AtariMapPacStartDirection = Direction.Right;

        private static List<Ghost> AtariMapGhosts = new List<Ghost> {
            new Ghost(new Coords {x = 6, y = 2}, Direction.Right, new RandomGhostLogic()),
            new Ghost(new Coords {x = 20, y = 2}, Direction.Left, new RandomGhostLogic())
        };

        private const string AtariMapData = "1111111111110111111111111" +
                                            "1000000001000001000000001" +
                                            "1011010101011101010101101" +
                                            "1000010000000000000100001" +
                                            "1110110111011101110110111" +
                                            "1000000001000001000000001" +
                                            "1011010101011101010101101" +
                                            "1000010000011100000100001" +
                                            "1110110111011101110110111" +
                                            "1000000001000001000000001" +
                                            "1011010101011101010101101" +
                                            "1000010000000000000100001" +
                                            "1110110111011101110110111" +
                                            "1000000001000001000000001" +
                                            "1011010101011101010101101" +
                                            "1000010000000000000100001" +
                                            "1111111111110111111111111";
        
        private static BoardLayout AtariMapLayout = _converter.Convert(AtariMapHeight, AtariMapWidth, AtariMapData);
        
        public Board AtariMapBoard = new Board(AtariMapWidth, AtariMapHeight, AtariMapPacStartX, AtariMapPacStartY, AtariMapPacStartDirection, AtariMapGhosts, AtariMapLayout);
    }
}