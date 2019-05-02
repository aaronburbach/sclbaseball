using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using SclBaseball.Models;

namespace SclBaseball.Data
{
    public class GameContext : DbContext
    {
        public GameContext() : base("GameContext")
        {
        }

        public DbSet<Game> Games { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}