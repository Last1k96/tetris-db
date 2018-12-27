using System;
using System.Data.Entity;

namespace TetrisDb
{
    internal class TetrisContext : DbContext
    {
        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    var sqliteConnectionInitializer = new SqliteCreateDatabaseIfNotExists<TetrisContext>(modelBuilder);
        //    Database.SetInitializer(sqliteConnectionInitializer);
        //}


        public TetrisContext() : base("name=TetrisContext") // "name=TetrisContext"
        {
            AppDomain.CurrentDomain.SetData("DataDirectory", System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Database"));
            //Database.SetInitializer(new DropCreateDatabaseIfModelChanges<TetrisContext>());
            Database.SetInitializer<TetrisContext>(new CreateDatabaseIfNotExists<TetrisContext>());

        }

        public DbSet<Player> Players { get; set; }
        public DbSet<Score> Scores { get; set; }
    }
}