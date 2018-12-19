using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TetrisDb
{
    public partial class Form1 : Form
    {
        public static TetrisGame game;

        void TimerHandler(TetrisGame.GameState state)
        {
            switch (state)
            {
                case TetrisGame.GameState.Paused:
                    gameTimer.Stop();
                    break;
                case TetrisGame.GameState.Empty:
                    break;
                case TetrisGame.GameState.StartNew:
                    gameTimer.Start();
                    break;
                case TetrisGame.GameState.Playing:
                    gameTimer.Start();
                    break;
            }
        }

        void PauseButtonHandler(TetrisGame.GameState state)
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

        public Form1()
        {
            InitializeComponent();

            game = new TetrisGame();
            game.OnGameStateChange += TimerHandler;
            game.OnGameStateChange += PauseButtonHandler;

            game.State = TetrisGame.GameState.Empty;
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            game.State = TetrisGame.GameState.Playing;
        }

        private void pauseButton_Click(object sender, EventArgs e)
        {
            if (game.State == TetrisGame.GameState.Playing)
            {
                game.State = TetrisGame.GameState.Paused;
            }
            else
            {
                game.State = TetrisGame.GameState.Playing;
            }
        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            game.OnGameTick();
            Redraw();
        }

        private void Redraw()
        {
            const int blockSize = 20;
            var bitmap = new Bitmap(TetrisGame.Width * blockSize, TetrisGame.Height * blockSize);
            var g = Graphics.FromImage(bitmap);
            g.Clear(Color.Black);

            // Draw Field
            for (int y = 0; y < TetrisGame.Height; y++)
            {
                for (int x = 0; x < TetrisGame.Width; x++)
                {
                    var block = game.Field[y, x];
                    if (block == -1) continue;
                    var fieldX = x * blockSize;
                    var fieldY = (TetrisGame.Height - y - 1) * blockSize;
                    g.FillRectangle(new SolidBrush(game.Colors[block]), fieldX, fieldY, blockSize, blockSize);
                }
            }

            // Draw moving peace
            if (game.CurrentTetramino == null) return;
            var pos = game.CurrentTetramino.Position;
            var colorIndex = game.CurrentTetraminoIndex();
            var brush = new SolidBrush(game.Colors[colorIndex]);
            for (int y = 0; y < 4; y++)
            {
                for (int x = 0; x < 4; x++)
                {
                    var block = game.CurrentTetramino.Block[y, x];
                    if (block == 0) continue;
                    var fieldX = (x + pos.X) * blockSize;
                    var fieldY = (TetrisGame.Height + y - pos.Y - 1) * blockSize;
                    g.FillRectangle(brush, fieldX, fieldY, blockSize, blockSize);
                }
            }

            fieldPanel.CreateGraphics().DrawImage(bitmap, new Point(0, 0));
        }
    }
}