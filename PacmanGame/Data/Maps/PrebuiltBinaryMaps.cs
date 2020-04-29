using System.Collections.Generic;
using PacmanGame.Business.Characters;
using PacmanGame.Business.GhostLogic;
using PacmanGame.Data.Enums;

namespace PacmanGame.Data.Maps {
    public static class PrebuiltBinaryMaps {
        private const int ArcadeMapHeight = 21;
        private const int ArcadeMapWidth = 19;
        private const int ArcadeMapPacStartX = 10;
        private const int ArcadeMapPacStartY = 16;
        private const Direction ArcadeMapPacStartDirection = Direction.Right;
        private static readonly List<LevelSetName> ArcadeMapSets = new List<LevelSetName>{LevelSetName.Basic};

        private static readonly List<Ghost> ArcadeMapGhosts = new List<Ghost> {
            new Ghost(5, 3, new RandomGhostLogic()),
            new Ghost(15, 3, new RandomGhostLogic())
        };

        private const string ArcadeMapBinaryData = "1111111111111111111" +
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
        
        public static readonly MapData ArcadeMap = new MapData(ArcadeMapSets, ArcadeMapHeight, ArcadeMapWidth, 
            ArcadeMapPacStartX, ArcadeMapPacStartY, ArcadeMapPacStartDirection, ArcadeMapGhosts, ArcadeMapBinaryData);

        private const int AtariMapHeight = 17;
        private const int AtariMapWidth = 25;
        private const int AtariMapPacStartX = 13;
        private const int AtariMapPacStartY = 14;
        private const Direction AtariMapPacStartDirection = Direction.Right;
        private static readonly List<LevelSetName> AtariMapSets = new List<LevelSetName>{LevelSetName.Basic}; 

        private static readonly List<Ghost> AtariMapGhosts = new List<Ghost> {
            new Ghost(6, 2, new RandomGhostLogic()),
            new Ghost(20, 2, new RandomGhostLogic())
        };

        private const string AtariMapBinaryData = "1111111111110111111111111" +
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
        
        public static MapData AtariMap = new MapData(AtariMapSets, AtariMapHeight, AtariMapWidth, 
            AtariMapPacStartX, AtariMapPacStartY, AtariMapPacStartDirection, AtariMapGhosts, AtariMapBinaryData);

        private const int GoogleMapHeight = 11;
        private const int GoogleMapWidth = 30;
        private const int GoogleMapPacStartX = 19;
        private const int GoogleMapPacStartY = 10;
        private const Direction GoogleMapPacStartDirection = Direction.Right;
        private static readonly List<LevelSetName> GoogleMapSets = new List<LevelSetName>{LevelSetName.Basic};

        private static readonly List<Ghost> GoogleMapGhosts = new List<Ghost> {
            new Ghost(5, 2, new RandomGhostLogic()),
            new Ghost(25, 3, new RandomGhostLogic())
        };

        private const string GoogleMapBinaryData = "111111111111111111111111111111" +
                                             "100000000000000001110001110001" +
                                             "101011110111111101110100000101" +
                                             "100010000000000000000101110001" +
                                             "111010110111011101110101110111" +
                                             "000010010111011100000101000000" +
                                             "111011110111011101110101110111" +
                                             "100000000000000000100000000001" +
                                             "101101111010111010101101110101" +
                                             "100000000010000010001101110001" +
                                             "111111111111111111111111111111";
        
        public static MapData GoogleMap = new MapData(GoogleMapSets, GoogleMapHeight, GoogleMapWidth, 
            GoogleMapPacStartX, GoogleMapPacStartY, GoogleMapPacStartDirection, GoogleMapGhosts, GoogleMapBinaryData);

        private const int MYOBMapHeight = 15;
        private const int MYOBMapWidth = 36;
        private const int MYOBMapPacStartX = 4;
        private const int MYOBMapPacStartY = 5;
        private const Direction MYOBMapPacStartDirection = Direction.Right;
        private static readonly List<LevelSetName> MYOBMapSets = new List<LevelSetName>{LevelSetName.Bonus};
        
        private static List<Ghost> MYOBMapGhosts = new List<Ghost>();

        private const string MYOBMapBinaryData = "111111111111111111111111111111111111" +
                                           "111111111111111111111111111001111111" +
                                           "111111111111111111111111111001111111" +
                                           "111111111111111111111111111001111111" +
                                           "111000010001101111001000011000001111" +
                                           "110000000100100110000011000000100111" +
                                           "110011001110000110010111101001110011" +
                                           "110011001110110010110111101001110011" +
                                           "110011001110110000110111001001110011" +
                                           "110011001110111000110000001000100111" +
                                           "110111101110111001111000111011001111" +
                                           "111111111111111001111111111111111111" +
                                           "111111111111110011111111111111111111" +
                                           "111111111111110111111111111111111111" +
                                           "111111111111111111111111111111111111";
        
        public static MapData MYOBMap = new MapData(MYOBMapSets, MYOBMapHeight, MYOBMapWidth, 
            MYOBMapPacStartX, MYOBMapPacStartY, MYOBMapPacStartDirection, MYOBMapGhosts, MYOBMapBinaryData);

        public static List<MapData> MapData = new List<MapData> {
            ArcadeMap,
            AtariMap,
            GoogleMap,
            MYOBMap
        };
    }
}