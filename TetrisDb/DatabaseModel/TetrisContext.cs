using System;
using System.Data.Common;
using System.Data.Entity;

namespace TetrisDb
{
    //internal class TetrisContext : DbContext
    //{
    //    public TetrisContext() : base("name=SQLiteContext") 
    //    {
    //        //Database.SetInitializer(new CreateDatabaseIfNotExists<TetrisContext>());
    //    }
    //    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    //    {
    //        var sqliteConnectionInitializer = new SqliteCreateDatabaseIfNotExists<TetrisContext>(modelBuilder);
    //        Database.SetInitializer(sqliteConnectionInitializer);
    //    }
    //    public DbSet<Player> Players { get; set; }
    //    public DbSet<Score> Scores { get; set; }
    //}

    public class TetrisContext : DbContext
    {
        public TetrisContext(string nameOrConnectionString = "SQLiteContext")
            : base(nameOrConnectionString)
        {
            Configure();
        }

        public TetrisContext(DbConnection connection, bool contextOwnsConnection)
            : base(connection, contextOwnsConnection)
        {
            Configure();
        }

        private void Configure()
        {
            Configuration.ProxyCreationEnabled = true;
            Configuration.LazyLoadingEnabled = true;
            //AppDomain.CurrentDomain.SetData("DataDirectory", System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Database"));
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            var initializer = new TetrisDbInitializer(modelBuilder);
            Database.SetInitializer(initializer);
        }

        public DbSet<Player> Players { get; set; }
        public DbSet<Score> Scores { get; set; }
    }
}