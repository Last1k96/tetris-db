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
                case TetrisGame.GameState.Pause:
                    gameTimer.Stop();
                    break;
                case TetrisGame.GameState.Empty:
                    break;
                case TetrisGame.GameState.StartNew:
                    gameTimer.Start();
                    break;
                case TetrisGame.GameState.Play:
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
                case TetrisGame.GameState.Play:
                    pauseButton.Enabled = true;
                    pauseButton.Text = "Пауза";
                    break;
                case TetrisGame.GameState.Pause:
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
            game.State = TetrisGame.GameState.Play;
        }

        private void pauseButton_Click(object sender, EventArgs e)
        {
            if (game.State == TetrisGame.GameState.Play)
            {
                game.State = TetrisGame.GameState.Pause;
            }
            else
            {
                game.State = TetrisGame.GameState.Play;
            }
        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            levelValue.Text = (Convert.ToInt32(levelValue.Text) + 1).ToString();
        }
    }
}
