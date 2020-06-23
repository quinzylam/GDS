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
        public DbSet<BibleBook> BibleBooks { get; set; }
        public DbSet<Verse> Verses { get; set; }
        public DbSet<Heading> Headings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>().HasIndex(x => x.ShortTitle);
            modelBuilder.Entity<Book>().HasIndex(x => x.Code);
            modelBuilder.Entity<Bible>().HasIndex(x => x.Code);
            modelBuilder.Entity<BibleBook>().HasIndex(x => x.LocalId).IsUnique();
            modelBuilder.Entity<BibleBook>().HasIndex(x => x.Version);
            modelBuilder.Entity<BibleBook>().HasIndex(x => x.BookCode);
            modelBuilder.Entity<Verse>().HasIndex(x => x.LocalId).IsUnique();
            modelBuilder.Entity<Verse>().HasIndex(x => x.ChapterNum);
            modelBuilder.Entity<Verse>().HasIndex(x => x.Position);
            modelBuilder.Entity<Heading>().HasIndex(x => x.Chapter);
            modelBuilder.Entity<Heading>().HasIndex(x => x.Position);
        }
    }
}