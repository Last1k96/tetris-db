using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TetrisDb
{
    public class TetrisGame
    {
        public enum GameState
        {
            Empty,
            StartNew,
            Play,
            Pause
        };

        public delegate void GameStateHandler(GameState currentGameState);
        public event GameStateHandler OnGameStateChange;

        private GameState state = GameState.Empty;
        public GameState State
        {
            get
            {
                return state;
            }
            set
            {
                state = value;
                OnGameStateChange(value);
            }
        } 

        private readonly Color[] Colors =
        {
            Color.Cyan,
            Color.Blue,
            Color.Orange,
            Color.Yellow,
            Color.Green,
            Color.Purple,
            Color.Red
        };

        private readonly List<Tetromino> Blocks = new List<Tetromino>
        {
            new I(),
            new J(),
            new L(),
            new O(),
            new S(),
            new T(),
            new Z()
        };



    }
}
