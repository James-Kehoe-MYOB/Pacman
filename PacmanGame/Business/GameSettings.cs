using System;
using System.Collections.Generic;
using System.Linq;
using PacmanGame.Client.UserInterface;
using PacmanGame.Data.Enums;
using PacmanGame.Data.LevelData;
using PacmanGame.Data.Maps;
using PacmanGame.DataAccess.BoardLayoutConverter;

namespace PacmanGame.Business {
    public class GameSettings {
        public IInput Input;

        public IOutput Output;
        
        public LevelSet LevelSet;
        
        public int Lives;

        public GameSettings(InputType inputType, OutputType outputType, LevelSetName levelSetName, int lives) {
            Input = AssignInput(inputType);
            Output = AssignOutput(outputType);
            LevelSet = AssignLevelSet(levelSetName);
            Lives = lives;
        }

        private static IInput AssignInput(InputType inputType) {
            return inputType switch {
                InputType.Key => new KeyInput(),
                InputType.Controller => new KeyInput(),
                _ => new KeyInput()
            };
        }
        
        private static IOutput AssignOutput(OutputType outputType) {
            return outputType switch {
                OutputType.Console => new ConsoleOutput(),
                OutputType.GUI => new ConsoleOutput(),
                _ => new ConsoleOutput()
            };
        }

        private static LevelSet AssignLevelSet(LevelSetName levelSetName) {
            
            var returnLevelSet = new LevelSet();
            
            var converter = new BinaryToBoardLayoutConverter();
            
            List<MapData> set = new List<MapData>();
            set.AddRange(PrebuiltBinaryMaps.MapData.Where(m => m.Sets.Contains(levelSetName)));

            foreach (var mapData in set) {
                try {
                    var convertedData = converter.Convert(mapData.Height, mapData.Width, mapData.Data);
                    var level = new Level(mapData.Width, mapData.Height, mapData.PacStartX, mapData.PacStartY, mapData.PacStartDirection, mapData.Ghosts, convertedData);
                    returnLevelSet.Add(level);
                }
                catch (Exception e) {
                    Console.WriteLine(e);
                    throw;
                }
            }

            return returnLevelSet;
        }
        
        
    }
}