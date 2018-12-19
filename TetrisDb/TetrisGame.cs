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
            New,
            Play,
            Pause
        };

        public GameState State { get; set; } = GameState.New;

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
