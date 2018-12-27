using System;
using System.Data.Entity;
using System.Drawing;
using System.Windows.Forms;

namespace TetrisDb
{
    public partial class MainForm : Form
    {
        private const int BlockSize = 30;
        public static TetrisGame Game;

        public MainForm()
        {
            InitializeComponent();

            Game = new TetrisGame();

            Game.OnGameStateChange += TimerHandler;
            Game.OnGameStateChange += PauseButtonHandler;
            Game.OnGameStateChange += OnStartHandler;
            Game.OnGameStateChange += OnFinishHandler;

            Game.OnFigurePlaced += LineCollapseHandler;
            Game.OnFigurePlaced += NextFigureHandler;
            Game.OnFigurePlaced += FinishHandler;

            startButton.DisableSelect();
            scoreButton.DisableSelect();
            pauseButton.DisableSelect();
        }

        private void UpdateScore()
        {
            gameTimer.Interval = (11 - Game.Score.Level) * 50;

            levelValue.Text = Game.Score.Level.ToString();
            linesValue.Text = Game.Score.Lines.ToString();
            pointsValue.Text = Game.Score.Points.ToString();
        }

        private void LineCollapseHandler()
        {
            var collapsed = Game.CollapseLines();
            if (collapsed == 0) return;

            UpdateScore();
           
            Redraw();
            gameTimer.Stop();
            gameTimer.Start(); // reset
        }



        private void OnFinishHandler(TetrisGame.GameState state)
        {
            if (state != TetrisGame.GameState.Finished) return;
            
            var form = new AskNameForm();
            form.ShowDialog(this);
        }

        private void OnStartHandler(TetrisGame.GameState state)
        {
            if (state != TetrisGame.GameState.StartNew) return;
            Game.Clear();
            Game.CycleTetramino();
            Game.Score.Reset();

            NextFigureHandler();
            UpdateScore();
        }

        private void FinishHandler()
        {
            if (Game.CanSpawnNext() == false)
                Game.State = TetrisGame.GameState.Finished;
        }

        private void DrawTetramino(Graphics g, Tetramino tetramino, int colorIndex)
        {
            var pos = tetramino.Position;
            for (var y = 0; y < 4; y++)
                for (var x = 0; x < 4; x++)
                {
                    var block = tetramino.Block[y, x];
                    if (block == 0) continue;
                    var fieldX = (x + pos.X) * BlockSize;
                    var fieldY = (TetrisGame.Height + y - pos.Y - 1) * BlockSize;
                    DrawBlock(g, colorIndex, fieldX, fieldY, BlockSize);
                }
        }

        private void NextFigureHandler()
        {
            Game.CycleTetramino();
            var bitmap = new Bitmap(4 * BlockSize, 4 * BlockSize);
            var g = Graphics.FromImage(bitmap);
            g.Clear(SystemColors.Control);
            var colorIndex = Game.TetraminoIndex(Game.NextTetramino);
            for (var y = 0; y < 4; y++)
                for (var x = 0; x < 4; x++)
                {
                    if (Game.NextTetramino.Block[y, x] == 0) continue;
                    var fieldX = x * BlockSize;
                    var fieldY = y * BlockSize;
                    DrawBlock(g, colorIndex, fieldX, fieldY, BlockSize);
                }

            nextFigurePicture.Image = bitmap;
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
                    Game.State = TetrisGame.GameState.Playing;
                    gameTimer.Start();
                    break;
                case TetrisGame.GameState.Playing:
                    gameTimer.Start();
                    break;
                case TetrisGame.GameState.Finished:
                    gameTimer.Stop();
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
                case TetrisGame.GameState.Finished:
                    pauseButton.Enabled = false;
                    pauseButton.Text = "Пауза";
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(state), state, null);
            }
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            Game.State = TetrisGame.GameState.StartNew;
            Redraw();
        }

        private void pauseButton_Click(object sender, EventArgs e)
        {
            switch (Game.State)
            {
                case TetrisGame.GameState.Playing:
                    Game.State = TetrisGame.GameState.Paused;
                    break;
                case TetrisGame.GameState.Paused:
                    Game.State = TetrisGame.GameState.Playing;
                    break;
            }
        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            Game.OnGameTick();
            Redraw();
        }

        private void DrawBlock(Graphics g, int colorIndex, int x, int y, int size)
        {
            size = size - 1;
            var color = Game.Colors[colorIndex];
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

            // Draw #
            var grayPen = new Pen(Color.FromArgb(255, 30, 30, 30));
            for (var y = 1; y < TetrisGame.Height; y++)
                g.DrawLine(grayPen, 0, y * BlockSize, Width * BlockSize, y * BlockSize);

            for (var x = 1; x < TetrisGame.Width; x++)
                g.DrawLine(grayPen, x * BlockSize, 0, x * BlockSize, Height * BlockSize);

            // Draw Field
            for (var y = 0; y < TetrisGame.Height; y++)
                for (var x = 0; x < TetrisGame.Width; x++)
                {
                    var block = Game.Field[y, x];
                    if (block == -1) continue;
                    var fieldX = x * BlockSize;
                    var fieldY = (TetrisGame.Height - y - 1) * BlockSize;
                    DrawBlock(g, block, fieldX, fieldY, BlockSize);
                }

            if (Game.CurrentTetramino != null)
            {
                // Draw shadow
                var shadow = Game.GetShadow(Game.CurrentTetramino);
                DrawTetramino(g, shadow, TetrisGame.ShadowColorIndex);

                // Draw moving peace
                var colorIndex = Game.TetraminoIndex(Game.CurrentTetramino);
                DrawTetramino(g, Game.CurrentTetramino, colorIndex);
            }

            fieldPicture.BackgroundImage = bitmap;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F2:
                    startButton_Click(sender, e);
                    break;
                case Keys.Escape:
                    pauseButton_Click(sender, e);
                    break;
            }

            if (Game.State != TetrisGame.GameState.Playing)
                return;
            switch (e.KeyCode)
            {
                case Keys.Left:
                    Game.MoveCurrentTetramino(TetrisGame.Direction.Left);
                    break;
                case Keys.Right:
                    Game.MoveCurrentTetramino(TetrisGame.Direction.Right);
                    break;
                case Keys.Down:
                    Game.MoveCurrentTetramino(TetrisGame.Direction.Down);
                    break;
                case Keys.Up:
                    Game.MoveCurrentTetramino(TetrisGame.Direction.Rotate);
                    break;
                case Keys.Space:
                    Game.MoveCurrentTetramino(TetrisGame.Direction.DownFast);
                    gameTimer.Stop();
                    gameTimer_Tick(sender, e);
                    gameTimer.Start();
                    break;
                default:
                    return;
            }

            e.Handled = true;
            Redraw();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Focus();
            Redraw();
        }

        private void scoreButton_Click(object sender, EventArgs e)
        {
            var form = new StatsForm();
            form.ShowDialog(this);
        }
    }
}