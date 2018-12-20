using System;
using System.Drawing;
using System.Windows.Forms;

namespace TetrisDb
{
    public partial class Form1 : Form
    {
        public static TetrisGame game;
        private const int BlockSize = 30;

        public Form1()
        {
            InitializeComponent();

            game = new TetrisGame();
            game.OnGameStateChange += TimerHandler;
            game.OnGameStateChange += PauseButtonHandler;
            game.OnGameStateChange += FocusHandler;
            game.OnGameStateChange += NextFigureOnStartHandler;
            game.OnFigurePlaced += NextFigureHandler;
            game.OnFigurePlaced += LineCollapseHandler;

            game.State = TetrisGame.GameState.Empty;
        }

        private void NextFigureOnStartHandler(TetrisGame.GameState state)
        {
            if (state == TetrisGame.GameState.StartNew)
            {
                game.CycleTetramino();
                NextFigureHandler();
            }
        }
        private void NextFigureHandler()
        {
            var bitmap = new Bitmap(4 * BlockSize, 4 * BlockSize);
            var g = Graphics.FromImage(bitmap);
            g.Clear(SystemColors.Control);
            var colorIndex = game.TetraminoIndex(game.NextTetramino);
            for (var y = 0; y < 4; y++)
            for (var x = 0; x < 4; x++)
            {
                var block = game.NextTetramino.Block[y, x];
                if (block == 0) continue;
                var fieldX = x * BlockSize;
                var fieldY = y * BlockSize;
                DrawBlock(g, colorIndex, fieldX, fieldY, BlockSize);
            }

            nextFigurePanel.CreateGraphics().DrawImage(bitmap, new Point(0, 0));
        }

        private void TimerHandler(TetrisGame.GameState state)
        {
            switch (state)
            {
                case TetrisGame.GameState.Paused:
                    gameTimer.Stop();
                    break;
                case TetrisGame.GameState.Empty:
                    break;
                case TetrisGame.GameState.StartNew:
                    game.State = TetrisGame.GameState.Playing;
                    gameTimer.Start();
                    break;
                case TetrisGame.GameState.Playing:
                    gameTimer.Start();
                    break;
            }
        }

        private void PauseButtonHandler(TetrisGame.GameState state)
        {
            switch (state)
            {
                case TetrisGame.GameState.Empty:
                    pauseButton.Enabled = false;
                    break;
                case TetrisGame.GameState.StartNew:
                    pauseButton.Enabled = true;
                    pauseButton.Text = "Пауза";
                    break;
                case TetrisGame.GameState.Playing:
                    pauseButton.Enabled = true;
                    pauseButton.Text = "Пауза";
                    break;
                case TetrisGame.GameState.Paused:
                    pauseButton.Enabled = true;
                    pauseButton.Text = "Продолжить";
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(state), state, null);
            }
        }

        private void FocusHandler(TetrisGame.GameState state)
        {
            Focus();
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            game.State = TetrisGame.GameState.StartNew;
        }

        private void pauseButton_Click(object sender, EventArgs e)
        {
            if (game.State == TetrisGame.GameState.Playing)
                game.State = TetrisGame.GameState.Paused;
            else
                game.State = TetrisGame.GameState.Playing;
        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            game.OnGameTick();
            Redraw();
        }

        private void DrawBlock(Graphics g, int colorIndex, int x, int y, int size)
        {
            size--;
            var color = game.Colors[colorIndex];
            g.FillRectangle(new SolidBrush(color), x, y, size, size);
            var lightPen = new Pen(ControlPaint.Light(color));
            var darkPen = new Pen(ControlPaint.Dark(color));
            g.DrawLine(lightPen, x, y, x + size, y);
            g.DrawLine(lightPen, x, y, x, y + size);
            g.DrawLine(darkPen, x + size, y, x + size, y + size);
            g.DrawLine(darkPen, x, y + size, x + size, y + size);
        }

        private void Redraw()
        {
            var bitmap = new Bitmap(TetrisGame.Width * BlockSize, TetrisGame.Height * BlockSize);
            var g = Graphics.FromImage(bitmap);
            g.Clear(Color.Black);

            // Draw Field
            for (var y = 0; y < TetrisGame.Height; y++)
                for (var x = 0; x < TetrisGame.Width; x++)
                {
                    var block = game.Field[y, x];
                    if (block == -1) continue;
                    var fieldX = x * BlockSize;
                    var fieldY = (TetrisGame.Height - y - 1) * BlockSize;
                    DrawBlock(g, block, fieldX, fieldY, BlockSize);
                }

            // Draw moving peace
            if (game.CurrentTetramino == null) return;
            var pos = game.CurrentTetramino.Position;
            var colorIndex = game.TetraminoIndex(game.CurrentTetramino);
            for (var y = 0; y < 4; y++)
                for (var x = 0; x < 4; x++)
                {
                    var block = game.CurrentTetramino.Block[y, x];
                    if (block == 0) continue;
                    var fieldX = (x + pos.X) * BlockSize;
                    var fieldY = (TetrisGame.Height + y - pos.Y - 1) * BlockSize;
                    DrawBlock(g, colorIndex, fieldX, fieldY, BlockSize);
                }

            fieldPanel.CreateGraphics().DrawImage(bitmap, new Point(0, 0));
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (game.State != TetrisGame.GameState.Playing)
                return;
            switch (e.KeyCode)
            {
                case Keys.Left:
                    game.MoveCurrentTetramino(TetrisGame.Direction.Left);
                    break;
                case Keys.Right:
                    game.MoveCurrentTetramino(TetrisGame.Direction.Right);
                    break;
                case Keys.Down:
                    game.MoveCurrentTetramino(TetrisGame.Direction.Down);
                    break;
                case Keys.Up:
                    game.MoveCurrentTetramino(TetrisGame.Direction.Rotate);
                    break;
                default:
                    return;
            }

            Redraw();
        }

        private void startButton_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Right:
                case Keys.Left:
                case Keys.Down:
                case Keys.Up:
                case Keys.Escape:
                    e.IsInputKey = true;
                    break;
            }
        }

        private void fieldPanel_Resize(object sender, EventArgs e)
        {
            levelValue.Text = fieldPanel.Width.ToString();
            pointsValue.Text = fieldPanel.Height.ToString();
        }
    }
}