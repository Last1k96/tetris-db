using System;
using System.Data.Entity;

namespace TetrisDb
{
    internal class TetrisContext : DbContext
    {
        public TetrisContext() : base("name=TetrisContext") 
        {
            AppDomain.CurrentDomain.SetData("DataDirectory", System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Database"));
            Database.SetInitializer(new CreateDatabaseIfNotExists<TetrisContext>());
        }

        public DbSet<Player> Players { get; set; }
        public DbSet<Score> Scores { get; set; }
    }
}