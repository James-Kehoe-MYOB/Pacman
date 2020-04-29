using System;

namespace PacmanGame.Data.Exceptions {
    public class InsufficientLevelDataException : Exception {
        public InsufficientLevelDataException() : base("ERROR: Insufficient amount of level data to fill level"){
            
        }
    }
}