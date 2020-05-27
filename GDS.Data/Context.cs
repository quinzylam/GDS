using GDS.Core.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace GDS.Data
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {
        }

        public DbSet<Bible> Bibles { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Chapter> Chapters { get; set; }
        public DbSet<Verse> Verses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Chapter>().HasIndex(x => x.LocalId).IsUnique();
            modelBuilder.Entity<Verse>().HasIndex(x => x.LocalId).IsUnique();
        }
    }
}