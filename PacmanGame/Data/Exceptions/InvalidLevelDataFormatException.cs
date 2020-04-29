using System;

namespace PacmanGame.Data.Exceptions {
    public class InvalidLevelDataFormatException : Exception {
        public InvalidLevelDataFormatException() : base("ERROR: Level Data is not in the correct format"){
            
        }
    }
}