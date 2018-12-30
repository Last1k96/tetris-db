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

        public enum GameState
        {
            Playing,
            Paused,
            Finished
        }

        public delegate void GameStateDelegate(GameState currentGameState);
        public event GameStateDelegate OnGameStateChange;
        private GameState _state = GameState.Finished;
        public GameState State
        {
            get => _state;
            set
            {
                _state = value;
                OnGameStateChange?.Invoke(value);
            }
        }

        public MainForm()
        {
            InitializeComponent();

            Game = new TetrisGame();

            Game.OnFigurePlaced += NextFigureHandler;
            Game.OnLineCollapsed += UpdateScore;
            Game.OnFinish += FinishHandler;

            startButton.DisableSelect();
            scoreButton.DisableSelect();
            pauseButton.DisableSelect();
        }

        private void UpdateScore(int count = 0)
        {
            levelValue.Text = Game.Score.Level.ToString();
            linesValue.Text = Game.Score.Lines.ToString();
            pointsValue.Text = Game.Score.Points.ToString();
            gameTimer.Interval = (11 - Game.Score.Level) * 50;

            if (gameTimer.Enabled)
            {
                gameTimer.Stop();
                gameTimer.Start(); // reset
            }
        }

        private void Start()
        {
            State = GameState.Playing;
            pauseButton.Enabled = true;
            Game.Clear();
            NextFigureHandler();
            UpdateScore();
            gameTimer.Start();
        }

        private void FinishHandler()
        {
            State = GameState.Finished;
            gameTimer.Stop();
            var form = new AskNameForm();
            form.ShowDialog(this);
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

        private void startButton_Click(object sender, EventArgs e)
        {
            Start();
            Redraw();
        }

        private void pauseButton_Click(object sender, EventArgs e)
        {
            switch (State)
            {
                case GameState.Playing:
                    State = GameState.Paused;
                    pauseButton.Text = "Продолжить";
                    gameTimer.Stop();
                    break;
                case GameState.Paused:
                    State = GameState.Playing;
                    pauseButton.Text = "Пауза";
                    gameTimer.Start();
                    break;
            }
        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            if (State != GameState.Playing) return;
            Game.NextTick();
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

            if (Game.CurrentTetramino != null && (State == GameState.Paused || State == GameState.Playing))
            {
                // Draw shadow
                var shadow = Game.DropDown(Game.CurrentTetramino);
                DrawTetramino(g, shadow, TetrisGame.ShadowColorIndex);

                // Draw moving peace
                var colorIndex = Game.TetraminoIndex(Game.CurrentTetramino);
                DrawTetramino(g, Game.CurrentTetramino, colorIndex);
            }

            fieldPicture.BackgroundImage = bitmap;
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F2:
                    startButton_Click(sender, e);
                    break;
                case Keys.F3:
                    scoreButton_Click(sender, e);
                    break;
                case Keys.Escape:
                    pauseButton_Click(sender, e);
                    break;
            }

            if (State != GameState.Playing)
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
                    Game.DropDownCurrentTetramino();
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

        private void MainForm_Load(object sender, EventArgs e)
        {
            Redraw();
        }

        private void scoreButton_Click(object sender, EventArgs e)
        {
            var form = new ScoreForm();
            form.ShowDialog(this);
        }

        private void MainForm_Leave(object sender, EventArgs e)
        {
            if (State == GameState.Playing)
            {
                pauseButton_Click(sender, e);
            }
        }
    }
}