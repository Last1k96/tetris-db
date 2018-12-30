using System.Data.Entity;
using SQLite.CodeFirst;

namespace TetrisDb
{
    public class TetrisDbInitializer : SqliteDropCreateDatabaseWhenModelChanges<TetrisContext>
    {
        public TetrisDbInitializer(DbModelBuilder modelBuilder)
            : base(modelBuilder)
        { }

        protected override void Seed(TetrisContext context)
        {
            // Here you can seed your core data if you have any.
        }
    }
}