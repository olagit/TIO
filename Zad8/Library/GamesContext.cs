using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Library
{
    public class GamesContext : DbContext
    {
        public GamesContext() : base("GamesContext") { }

        public DbSet<Game> Games { get; set; }
        public DbSet<Store> Stores { get; set; }

        /*protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("public");
            base.OnModelCreating(modelBuilder);
        }*/
    }
}
