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
            levelValue.Text = (Convert.ToInt32(levelValue.Text) + 1).ToString();
        }
    }
}
