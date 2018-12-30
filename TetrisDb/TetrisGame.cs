using System;
using System.Collections.Generic;
using System.Drawing;

namespace TetrisDb
{
    public class TetrisGame
    {
        public delegate void FigurePlacedDelegate();

        public delegate void LineCollapsedDelegate(int count);

        public delegate void FinishDelegate();

        public enum Direction
        {
            None,
            Right,
            Left,
            Down,
            Rotate
        }

        public static readonly int Width = 10;
        public static readonly int Height = 20;
        public static readonly int ShadowColorIndex = 7;

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

        public TetrisGame()
        {
            Clear();
        }

        public Score Score { get; } = new Score();
        public Tetramino CurrentTetramino { get; private set; }
        public Tetramino NextTetramino { get; private set; }
        public int[,] Field { get; private set; }

        public event FigurePlacedDelegate OnFigurePlaced;
        public event LineCollapsedDelegate OnLineCollapsed;
        public event FinishDelegate OnFinish;

        private void UpdateScore(int linesCount)
        {
            if (linesCount <= 0 || linesCount > 4) return;
            int[] pointsForLineCollapsing = { 40, 100, 300, 1200 };
            Score.Lines += linesCount;
            Score.Level = Score.Lines / 10 + 1;
            if (Score.Level > 10) Score.Level = 10;
            Score.Points += pointsForLineCollapsing[linesCount - 1];
        }

        private void ResetScore()
        {
            Score.Level = 1;
            Score.Lines = 0;
            Score.Points = 0;
        }

        private void CycleTetramino()
        {
            CurrentTetramino = NextTetramino ?? GenerateTetramino();
            NextTetramino = GenerateTetramino();
            if (Move(CurrentTetramino, Direction.None) == null)
            {
                OnFinish?.Invoke();
            }
        }

        public void Clear()
        {
            Field = new int[Height + 4, Width];
            for (var i = 0; i < Height + 4; i++)
            for (var j = 0; j < Width; j++)
                Field[i, j] = -1;
            CycleTetramino();
            ResetScore();
        }

        private void CollapseLines()
        {
            var lineToCollapse = new List<int>();

            // Count lines to collapse
            for (var y = 0; y < Height; y++)
            {
                var x = 0;
                for (; x < Width; x++)
                    if (Field[y, x] == -1)
                        break;

                if (x == Width) lineToCollapse.Add(y);
            }

            // Collapsing lines
            for (var line = lineToCollapse.Count - 1; line >= 0; line--)
            for (var i = lineToCollapse[line]; i < Height; i++)
            for (var j = 0; j < Width; j++)
                Field[i, j] = Field[i + 1, j];

            UpdateScore(lineToCollapse.Count);

            OnLineCollapsed?.Invoke(lineToCollapse.Count);
        }

        public Tetramino DropDown(Tetramino tetramino)
        {
            Tetramino down;
            do
            {
                down = Move(tetramino, Direction.Down);
                tetramino = down ?? tetramino;
            } while (down != null);

            return tetramino;
        }

        public void DropDownCurrentTetramino()
        {
            CurrentTetramino = DropDown(CurrentTetramino);
        }

        private Tetramino Move(Tetramino tetramino, Direction dir)
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

            CollapseLines();
            CycleTetramino();

            OnFigurePlaced?.Invoke();
        }

        public bool MoveCurrentTetramino(Direction dir)
        {
            var tetramino = Move(CurrentTetramino, dir);

            if (tetramino == null && dir == Direction.Rotate)
            {
                // try bump left
                tetramino = Move(CurrentTetramino, Direction.Left);
                if (tetramino != null) tetramino = Move(tetramino, Direction.Rotate);

                // try bump right
                if (tetramino == null)
                {
                    tetramino = Move(CurrentTetramino, Direction.Right);
                    if (tetramino != null) tetramino = Move(tetramino, Direction.Rotate);
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

        public void NextTick()
        {
            var tetramino = Move(CurrentTetramino, Direction.Down);
            if (tetramino == null)
                PlaceTetramino(CurrentTetramino);
            else
                CurrentTetramino = tetramino;
        }
        
    }
}