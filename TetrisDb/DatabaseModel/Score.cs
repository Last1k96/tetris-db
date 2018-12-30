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
        public int Level { get; set; }
        public int Lines { get; set; }
        public int Points { get; set; }

        public virtual Player Player { get; set; }
    }
}
