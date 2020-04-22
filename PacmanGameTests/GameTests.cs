using PacmanGame;
using Xunit;

namespace PacmanGameTests {
    public class GameTests {
        [Fact(DisplayName = "Game is won if all pellets are eaten")]

        public void GameIsWonIfAllPelletsAreEaten() {
            
            var game = new Game() {
                PelletCount = 0
            };

            game.CheckWin();
            
            Assert.True(game.HasWon);
        }
    }
}