using PacmanGame;
using Xunit;

namespace PacmanGameTests {
    public class PelletTests {
        [Theory(DisplayName = "Pellet displays correctly depending on whether it has or has not been eaten")]
        [InlineData(false, Pellet.Default)]
        [InlineData(true, Pellet.Eaten)]

        public void PelletDisplaysCorrectlyDependingOnWhetherItHasOrHasNotBeenEaten(bool isEaten, string display) {

            var pellet = new Pellet(1, 1) {IsEaten = isEaten};

            pellet.UpdateDisplay();
            
            Assert.Equal(display, pellet.Display);
        }
    }
}