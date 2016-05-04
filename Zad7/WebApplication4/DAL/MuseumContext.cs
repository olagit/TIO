using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication4.Models;
using System.Data.Entity;

namespace WebApplication4.DAL
{
    public class MuseumContext : DbContext
    {
        public MuseumContext() : base("MuseumContext") { }

        public DbSet<Artist> Artists { get; set; }
        public DbSet<Painting> Paintings { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("public");
            base.OnModelCreating(modelBuilder);
        }
    }
}