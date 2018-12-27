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
    public partial class ScoreForm : Form
    {
        public ScoreForm()
        {
            InitializeComponent();

            button1.DisableSelect();
            button2.DisableSelect();
        }

        private void UpdateList()
        {
            scoreListView.Items.Clear();

            using (var db = new TetrisContext())
            {
                foreach (var score in db.Scores)
                {
                    string[] row =
                    {
                        score.Player.Name,
                        score.Level.ToString(),
                        score.Lines.ToString(),
                        score.Points.ToString()
                    };

                    var item = new ListViewItem(row);
                    scoreListView.Items.Add(item);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (var db = new TetrisContext())
            {
                db.Scores.RemoveRange(db.Scores);
                db.Players.RemoveRange(db.Players);
                db.SaveChanges();
            }
            UpdateList();
        }

        private void StatsForm_Load(object sender, EventArgs e)
        {
            UpdateList();
        }

        private void StatsForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
    }
}
