using System;
using System.Collections.Generic;
using System.Drawing;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;

namespace TetrisDb
{
    public class TetrisGame
    {
        public const int width = 10;
        public const int height = 20;

        public delegate void GameStateHandler(GameState currentGameState);

        public enum GameState
        {
            Empty,
            StartNew,
            Playing,
            Paused
        }

        private readonly List<Tetromino> TetrominoList = new List<Tetromino>
        {
            new I(),
            new J(),
            new L(),
            new O(),
            new S(),
            new T(),
            new Z()
        };

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

        public int[,] Field = new int[width, height + 4];

        public Tetromino CurrentTetromino = null;

        private enum Move
        {
            Right,
            Left,
            Down,
            Rotate,

        };

        private bool CanMove(Move dir)
        {
            var moved = CurrentTetromino;
            switch (dir)
            {
                case Move.Right:
                    moved.Position.X++;
                    break;
                case Move.Left:
                    moved.Position.X--;
                    break;
                case Move.Down:
                    moved.Position.Y--;
                    break;
                case Move.Rotate:
                    moved.Rotate();
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(dir), dir, null);
            }

            for (var y = 0; y < 4; y++)
            {
                for (var x = 0; x < 4; x++)
                {
                    if (moved.Block[y, x] != 0)
                    {
                        Point newPos = new Point(moved.Position.Y + y, moved.Position.X + x);
                        if (Field[newPos.Y, newPos.X] != -1)
                        {
                            return false;
                        }
                    }
                }
            }

            return true;
        }

        private void PlaceTetramino()
        {
            var pos = CurrentTetromino.Position;
            var block = CurrentTetromino.Block;
            for (int y = 0; y < 4; y++)
            {
                for (int x = 0; x < 4; x++)
                {
                    if (CurrentTetromino.Block[])
                    {

                    }
                }
            }
            Field
        }

        public void OnGameTick()
        {
            if (CurrentTetromino == null)
            {
                CurrentTetromino = TetrominoList[new Random().Next() % TetrominoList.Count];
                return;
            }

            if (CanMove(Move.Down))
            {
                CurrentTetromino.Position.Y--;
            }
            else
            {
                PlaceTetramino();
            }
        }

        private GameState state = GameState.Empty;

        public GameState State
        {
            get => state;
            set
            {
                state = value;
                OnGameStateChange(value);
            }
        }

        public event GameStateHandler OnGameStateChange;
    }
}