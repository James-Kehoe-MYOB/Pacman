using System;
using Microsoft.Extensions.Configuration;
using PacmanGame.Business;
using PacmanGame.Data.Enums;
using PacmanGame.Data.Exceptions;

namespace PacmanGame.DataAccess {
    public static class GameSettingsConstructor {
        private const string InputKey = "Input";
        private const string OutputKey = "Output";
        private const string LevelSetKey = "Level Set";
        private const string LivesKey = "Lives";

        public static GameSettings LoadSettings(string path) {
            var config = new ConfigurationBuilder()
                .AddJsonFile(path)
                .Build();
            
            ValidateConfig(config);

            var input = (InputType) Enum.Parse(typeof(InputType), config[InputKey]);
            var output = (OutputType) Enum.Parse(typeof(OutputType), config[OutputKey]);
            var levelSet = (LevelSetName) Enum.Parse(typeof(LevelSetName), config[LevelSetKey]);
            var lives = int.Parse(config[LivesKey]);
            
            return new GameSettings(input, output, levelSet, lives);
        }

        private static void ValidateConfig(IConfiguration config) {
            ValidateInput(config[InputKey]);
            ValidateOutput(config[OutputKey]);
            ValidateLevelSet(config[LevelSetKey]);
            ValidateLives(config[LivesKey]);
        }
        
        private static void ValidateLives(string Lives)
        {
            if (!int.TryParse(Lives, out var i))
            {
                throw new InvalidSettingsConfigurationException(
                    $"Lives must be an integer. '{Lives}' is not an integer"
                );
            }
            if (i < 1)
            {
                throw new InvalidSettingsConfigurationException(
                    $"Lives must be at least 1. '{Lives}' is too small."
                );
            }
        }
        private static void ValidateInput(string potentialEnum)
        {
            if (Enum.IsDefined(typeof(InputType), potentialEnum)) return;
            var options = string.Join(", ", Enum.GetNames(typeof(InputType)));
            throw new InvalidSettingsConfigurationException(
                $"'{potentialEnum}' is not a recognised input type. " +
                $"/n Valid examples types include {options}."
            );
        }
        
        private static void ValidateOutput(string potentialEnum)
        {
            if (Enum.IsDefined(typeof(OutputType), potentialEnum)) return;
            var options = string.Join(", ", Enum.GetNames(typeof(OutputType)));
            throw new InvalidSettingsConfigurationException(
                $"'{potentialEnum}' is not a recognised output type. " +
                $"/n Valid examples include {options}."
            );
        }
        
        private static void ValidateLevelSet(string potentialEnum)
        {
            if (Enum.IsDefined(typeof(LevelSetName), potentialEnum)) return;
            var options = string.Join(", ", Enum.GetNames(typeof(LevelSetName)));
            throw new InvalidSettingsConfigurationException(
                $"'{potentialEnum}' is not a recognised level set name. " +
                $"/n Valid examples include {options}."
            );
        }
        
    }
}