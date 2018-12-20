﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms.VisualStyles;

namespace TetrisDb
{
    public class TetrisGame
    {
        public delegate void FigurePlacedDelegate();

        public delegate void GameStateDelegate(GameState currentGameState);

        public enum Direction
        {
            None,
            Right,
            Left,
            Down,
            Rotate,
            DownFast
        }

        public enum GameState
        {
            Empty,
            StartNew,
            Playing,
            Paused,
            Finished
        }

        public const int Width = 10;
        public const int Height = 20;
        public static readonly int[] PointsForLineCollapsing = {40, 100, 300, 1200};

        public readonly Color[] Colors =
        {
            Color.Cyan,
            Color.Blue,
            Color.Orange,
            Color.Yellow,
            Color.Green,
            Color.Purple,
            Color.Red
        };

        private readonly List<Tetramino> TetrominoList = new List<Tetramino>
        {
            new I(),
            new J(),
            new L(),
            new O(),
            new S(),
            new T(),
            new Z()
        };

        private GameState _state = GameState.Empty;

        public Tetramino CurrentTetramino;

        public int[,] Field;
        public Tetramino NextTetramino;

        public TetrisGame()
        {
            Clear();
        }

        public GameState State
        {
            get => _state;
            set
            {
                _state = value;
                OnGameStateChange?.Invoke(value);
            }
        }

        public event FigurePlacedDelegate OnFigurePlaced;

        public Tetramino CycleTetramino()
        {
            var prev = CurrentTetramino;
            CurrentTetramino = NextTetramino ?? GenerateTetramino();
            NextTetramino = GenerateTetramino();
            return prev;
        }

        public void Clear()
        {
            Field = new int[Height + 4, Width];
            for (var i = 0; i < Height + 4; i++)
            for (var j = 0; j < Width; j++)
                Field[i, j] = -1;
        }

        public int CollapseLines()
        {
            var lineToCollapse = new List<int>();
            for (var y = 0; y < Height; y++)
            {
                var x = 0;
                for (; x < Width; x++)
                    if (Field[y, x] == -1)
                        break;

                if (x == Width) lineToCollapse.Add(y);
            }

            for (int line = lineToCollapse.Count-1; line >= 0; line--)
                for (var i = lineToCollapse[line]; i < Height; i++)
                for (var j = 0; j < Width; j++)
                    Field[i, j] = Field[i + 1, j];

            return lineToCollapse.Count;
        }
        
        private Tetramino CanMove(Direction dir)
        {
            if (CurrentTetramino == null) return null;
            var moved = (Tetramino) CurrentTetramino.Clone();
            switch (dir)
            {
                case Direction.None:
                    break;
                case Direction.Right:
                    moved.Position.X++;
                    break;
                case Direction.Left:
                    moved.Position.X--;
                    break;
                case Direction.Down:
                    moved.Position.Y--;
                    break;
                case Direction.Rotate:
                    moved.Rotate();
                    break;
                case Direction.DownFast:
                    Tetramino down;
                    do
                    {
                        down = CanMove(Direction.Down);
                        CurrentTetramino = down ?? CurrentTetramino;
                    } while (down != null);

                    return CurrentTetramino;
                default:
                    throw new ArgumentOutOfRangeException(nameof(dir), dir, null);
            }

            for (var y = 0; y < 4; y++)
            {
                var my = moved.Position.Y - y;
                for (var x = 0; x < 4; x++)
                {
                    var mx = moved.Position.X + x;
                    if (moved.Block[y, x] == 0) continue;
                    if (my < 0 || mx < 0 || mx >= Width || Field[my, mx] != -1)
                        return null;
                }
            }

            return moved;
        }

        public int TetraminoIndex(Tetramino tetramino)
        {
            return TetrominoList.FindIndex(t => t.GetType() == tetramino.GetType());
        }

        private void PlaceTetramino()
        {
            if (CurrentTetramino == null) return;
            var pos = CurrentTetramino.Position;
            var block = CurrentTetramino.Block;
            var colorIndex = TetraminoIndex(CurrentTetramino);

            for (var y = 0; y < 4; y++)
            {
                var my = pos.Y - y;
                for (var x = 0; x < 4; x++)
                {
                    var mx = pos.X + x;
                    if (my < 0 || mx < 0 || mx > Width || block[y, x] == 0) continue;
                    Field[my, mx] = colorIndex;
                }
            }

            CurrentTetramino = NextTetramino;
            NextTetramino = GenerateTetramino();
            OnFigurePlaced?.Invoke();
        }

        public bool MoveCurrentTetramino(Direction dir)
        {
            var tetramino = CanMove(dir);

            if (tetramino == null) return false;
            CurrentTetramino = tetramino;
            return true;

        }

        private Tetramino GenerateTetramino()
        {
            return (Tetramino) TetrominoList[new Random().Next() % TetrominoList.Count].Clone();
        }

        public void OnGameTick()
        {
            var tetramino = CanMove(Direction.Down);
            if (tetramino == null)
                PlaceTetramino();
            else
                CurrentTetramino = tetramino;
        }

        public event GameStateDelegate OnGameStateChange;
    }
}