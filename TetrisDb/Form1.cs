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
        public static TetrisGame game = new TetrisGame();
        public Form1()
        {
            InitializeComponent();
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            game.State = TetrisGame.GameState.Play;
        }
    }
}
