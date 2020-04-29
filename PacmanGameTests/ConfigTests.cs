using System;
using System.IO;
using PacmanGame.Data.Exceptions;
using PacmanGame.DataAccess;
using Xunit;

namespace PacmanGameTests {
    public class ConfigTests {

        [Fact(DisplayName = "Can create valid settings object from valid data")]

        public void CanCreateValidSettingsObjectFromValidData() {
            var settings = GameSettingsConstructor.LoadSettings(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "TestData", "SuccessfulConfig.json"));
            
            Assert.Equal(3, settings.Lives);
        }
        
        [Theory(DisplayName = "Attempting to build an invalid settings object throws exception")]
        [InlineData("InvalidInputConfig.json")]
        [InlineData("InvalidOutputConfig.json")]
        [InlineData("InvalidLivesConfig.json")]
        [InlineData("InvalidLevelPackConfig.json")]

        public void AttemptingToBuildAnInvalidSettingsObjectThrowsException(string path) {

            Assert.Throws<InvalidSettingsConfigurationException>(() =>
                GameSettingsConstructor.LoadSettings(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "TestData",
                    path)));
        }
        
    }
}