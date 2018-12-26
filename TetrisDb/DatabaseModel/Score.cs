using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TetrisDb
{
    public class Score
    {
        public int Id { get; set; }
        public int Level { get; private set; }
        public int Lines { get; private set; }
        public int Points { get; private set; }

        public Player Player { get; set; }

        public void Update(int linesCount)
        {
            if (linesCount <= 0 || linesCount > 4) return;
            int[] pointsForLineCollapsing = { 40, 100, 300, 1200 };
            Lines += linesCount;
            Level = Lines / 10 + 1;
            if (Level > 10) Level = 10;
            Points += pointsForLineCollapsing[linesCount - 1];
        }

        public void Reset()
        {
            Level = 1;
            Lines = 0;
            Points = 0;
        }
    }

}
