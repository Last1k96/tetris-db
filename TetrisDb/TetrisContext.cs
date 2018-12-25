using System.Data.Entity;
using System.Runtime.InteropServices;

namespace TetrisDb
{
    class TetrisContext : DbContext
    {
        public TetrisContext() : base("TetrisContext")
        {
        }

        public DbSet<Player> Players { get; set; }
        public DbSet<Score> Scores { get; set; }
    }
}
