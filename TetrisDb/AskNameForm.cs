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
    public partial class AskNameForm : Form
    {
        public AskNameForm()
        {
            InitializeComponent();
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            using (var db = new TetrisContext())
            {
                var name = nameBox.Text;
                var player = db.Players.SingleOrDefault(p => p.Name == name);
                if (player == null)
                {
                    player = new Player { Name = name };
                    player = db.Players.Add(player);
                }

                var score = MainForm.Game.Score;
                score.Player = player;
                db.Scores.Add(score);
                db.SaveChanges();
            }

            this.Close();
        }

        private void nameBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                okButton_Click(sender, e);
            }

            e.Handled = true;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
