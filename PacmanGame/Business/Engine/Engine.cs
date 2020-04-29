using System.Collections.Generic;
using System.Linq;
using System.Timers;
using PacmanGame.Business.Characters;
using PacmanGame.Business.Engine.Timer;
using PacmanGame.Business.GameObjects;
using PacmanGame.Client.UserInterface;
using PacmanGame.Data.Enums;
using PacmanGame.Data.LevelData;

namespace PacmanGame.Business.Engine {
    public class Engine : IEngine {
        public bool HasWon { get; private set; }
        public Level Level { get; private set; }
        public Pacman Pacman { get; }
        public GameState State { get; set; }
        public List<Pellet> ActivePellets { get; } = new List<Pellet>();
        public List<Ghost> Ghosts { get; set; } = new List<Ghost>();
        private IInput InputHandler { get; }
        private IOutput OutputHandler { get; }
        private ITimer GameTimer { get; } 

        public Engine(Level defaultLevel, IInput inputHandler, IOutput outputHandler, ITimer gameTimer) {
            InputHandler = inputHandler;
            OutputHandler = outputHandler;
            GameTimer = gameTimer;
            GameTimer.InitTimer(200, Step);
            Pacman = new Pacman(defaultLevel.PacStartX, defaultLevel.PacStartY, 
                defaultLevel.PacStartDirection, outputHandler);
            HasWon = false;
            LoadLevel(defaultLevel);
        }

        public void Run() {
            
            ResetCharacters();
            OutputHandler.WriteBoard(Level);
            OutputHandler.WriteGameObjects(Pacman, ActivePellets, Ghosts);
            OutputHandler.Pause(1000);
            
            GameTimer.Start();
            State = GameState.Running;
            
            while (State == GameState.Running) {
                if (InputHandler.KeyAvailable()) {
                    var newDirection = InputHandler.TakeInput(Pacman.Direction);
                    ChangePacmanDirection(newDirection);
                }
            }
            
            GameTimer.Stop();
        }
        
        public void LoadLevel(Level level) {
            State = GameState.Initialising;
            Level = level;
            Ghosts.Clear();
            foreach (var ghost in level.Ghosts) {
                Ghosts.Add(new Ghost(ghost.X, ghost.Y, ghost.Logic));
            }
            ResetCharacters();
            FillPellets();
            HasWon = false;
        }
        
        private void Step(object source, ElapsedEventArgs e) {
            UpdateBoard();
            CheckWin();
        }

        public void CheckWin() {
            if (ActivePellets.Count == 0) {
                HasWon = true;
                State = GameState.Finished;
            }
            else if (PacmanTouchingGhost()) {
                HasWon = false;
                State = GameState.Finished;
            }
            else {
                HasWon = false;
                State = GameState.Running;
            }
        }
        
        private void FillPellets() {
            ActivePellets.Clear();
            var emptySpots = Level.Layout.Where(m => m.State == TileState.Empty);
            foreach (var tile in emptySpots) {
                if (!(tile.X == Pacman.X && tile.Y == Pacman.Y)) {
                    ActivePellets.Add(new Pellet(tile.X, tile.Y));
                }
            }
        }

        private void ChangePacmanDirection(Direction direction) {
            if (CheckWallCollision(direction, Pacman)) return;
            Pacman.Direction = direction;
            Pacman.Velocity = 1;
        }

        public void UpdateBoard() {
            UpdatePacmanPosition();
            CheckWin();
            UpdatePelletList();
            UpdateGhostPositions();
            if (State == GameState.Running) {
                OutputHandler.WriteGameObjects(Pacman, ActivePellets, Ghosts);
            }
        }

        private void UpdatePacmanPosition() {
            if (CheckWallCollision(Pacman.Direction, Pacman)) {
                Pacman.Velocity = 0;
            }
            Pacman.Sprite = OutputHandler.UpdatePacmanSprite(Pacman.Direction);
            OutputHandler.ClearTileDisplay(Pacman.X, Pacman.Y, Level);
            Move(Pacman);
        }

        private bool PacmanTouchingGhost() {
            return Ghosts.Any(ghost => Pacman.X == ghost.X && Pacman.Y == ghost.Y);
        }

        private void UpdatePelletList() {
            var pacPosition = ActivePellets.Find(m => m.X == Pacman.X && m.Y == Pacman.Y);
            ActivePellets.Remove(pacPosition);
        }

        private void UpdateGhostPositions() {
            foreach (var ghost in Ghosts) {
                ghost.Velocity = 1;
                OutputHandler.ClearTileDisplay(ghost.X, ghost.Y, Level);
                while (CheckWallCollision(ghost.Direction, ghost)) {
                    ghost.Direction = ghost.ChooseDirection();
                }
                Move(ghost);
            }
        }

        private bool CheckWallCollision(Direction direction, ICharacter character) {
            var collision = new Collision(character) {Direction = direction};
            Move(collision);
            return Level.Layout.Find(m => m.X == collision.X && m.Y == collision.Y).State == TileState.Wall;
        }
        
        private void ResetCharacters() {
            Pacman.X = Level.PacStartX;
            Pacman.Y = Level.PacStartY;
            Pacman.Update(Level.PacStartDirection, 1);

            for (int i = 0; i < Ghosts.Count; i++) {
                Ghosts[i].X = Level.Ghosts[i].X;
                Ghosts[i].Y = Level.Ghosts[i].Y;
            }
        }

        private void Move(ICharacter character) {
            
            switch (character.Direction) {
                case Direction.Up:
                    if (character.Y == 1 && character.Velocity == 1) {
                        character.Y = Level.Height;
                    }
                    else {
                        character.Y -= character.Velocity;
                    }
                    break;
                case Direction.Down:
                    if (character.Y == Level.Height && character.Velocity == 1) {
                        character.Y = 1;
                    }
                    else {
                        character.Y += character.Velocity;
                    }
                    break;
                case Direction.Left:
                    if (character.X == 1 && character.Velocity == 1) {
                        character.X = Level.Width;
                    }
                    else {
                        character.X -= character.Velocity;
                    }
                    break;
                case Direction.Right:
                    if (character.X == Level.Width && character.Velocity == 1) {
                        character.X = 1;
                    }
                    else {
                        character.X += character.Velocity;
                    }
                    break;
                default:
                    character.X += 0;
                    character.Y += 0;
                    break;
            }
            OutputHandler.WriteSprite(character);
        }
    }
}