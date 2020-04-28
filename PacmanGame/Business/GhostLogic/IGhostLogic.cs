using PacmanGame.Data.Enums;

namespace PacmanGame.Business.GhostLogic {
    public interface IGhostLogic {
        public Direction ChooseDirection();
    }
}