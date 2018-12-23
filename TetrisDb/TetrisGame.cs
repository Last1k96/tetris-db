using System;
using System.Collections.Generic;
using System.Drawing;
using System.Net;

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
        public static int ShadowColorIndex = 7;
        public static readonly int[] PointsForLineCollapsing = {40, 100, 300, 1200};

        private readonly List<Tetramino> _tetraminoList = new List<Tetramino>
        {
            new I(),
            new J(),
            new L(),
            new O(),
            new S(),
            new T(),
            new Z()
        };

        public readonly Color[] Colors =
        {
            Color.Cyan,
            Color.Blue,
            Color.Orange,
            Color.Yellow,
            Color.Green,
            Color.Purple,
            Color.Red,
            Color.FromArgb(255, 40, 40, 40) // Shadow
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

            for (var line = lineToCollapse.Count - 1; line >= 0; line--)
            for (var i = lineToCollapse[line]; i < Height; i++)
            for (var j = 0; j < Width; j++)
                Field[i, j] = Field[i + 1, j];

            return lineToCollapse.Count;
        }

        public Tetramino GetShadow(Tetramino tetramino)
        {
            bool CanMoveDown(Tetramino t)
            {
                for (var y = 0; y < 4; y++)
                {
                    var my = t.Position.Y - y - 1;
                    for (var x = 0; x < 4; x++)
                    {
                        var mx = t.Position.X + x;
                        if (t.Block[y, x] == 0) continue;
                        if (my < 0 || mx < 0 || mx >= Width || Field[my, mx] != -1) return false;
                    }
                }

                return true;
            }

            var shadow = (Tetramino) tetramino.Clone();
            while (CanMoveDown(shadow)) shadow.Position.Y--;
            return shadow;
        }

        private Tetramino CanMove(Tetramino tetramino, Direction dir)
        {
            if (tetramino == null) return null;
            var moved = (Tetramino) tetramino.Clone();
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
                        down = CanMove(moved, Direction.Down);
                        moved = down ?? moved;
                    } while (down != null);

                    return moved;
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

        public bool CanSpawnNext()
        {
            return CanMove(NextTetramino, Direction.None) != null;
        }

        public int TetraminoIndex(Tetramino tetramino)
        {
            return _tetraminoList.FindIndex(t => t.GetType() == tetramino.GetType());
        }

        private void PlaceTetramino(Tetramino tetramino)
        {
            if (tetramino == null) return;
            var pos = tetramino.Position;
            var block = tetramino.Block;
            var colorIndex = TetraminoIndex(tetramino);

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

            OnFigurePlaced?.Invoke();
        }

        public bool MoveCurrentTetramino(Direction dir)
        {
            var tetramino = CanMove(CurrentTetramino, dir);

            if (tetramino == null && dir == Direction.Rotate)
            {
                // try bump left
                tetramino = CanMove(CurrentTetramino, Direction.Left);
                if (tetramino != null) tetramino = CanMove(tetramino, Direction.Rotate);

                // try bump right
                if (tetramino == null)
                {
                    tetramino = CanMove(CurrentTetramino, Direction.Right);
                    if (tetramino != null) tetramino = CanMove(tetramino, Direction.Rotate);
                }
            }

            if (tetramino == null) return false;

            CurrentTetramino = tetramino;
            return true;
        }

        private Tetramino GenerateTetramino()
        {
            return (Tetramino) _tetraminoList[new Random().Next() % _tetraminoList.Count].Clone();
        }

        public void OnGameTick()
        {
            var tetramino = CanMove(CurrentTetramino, Direction.Down);
            if (tetramino == null)
                PlaceTetramino(CurrentTetramino);
            else
                CurrentTetramino = tetramino;
        }

        public event GameStateDelegate OnGameStateChange;
    }
}