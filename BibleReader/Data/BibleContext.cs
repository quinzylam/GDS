using BibleReader.Models;
using BibleReader.Models.Bible;
using BibleReader.Properties;
using Microsoft.EntityFrameworkCore;
using System;
using System.IO;

namespace BibleReader.Data
{
    public class BibleContext : DbContext
    {
        private readonly string bible = "KJV+";

        internal BibleContext(string bibleTranslation)
        {
            bible = bibleTranslation;
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Verse> Verses { get; set; }
        public DbSet<Info> Info { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Verse>().HasKey(v => new { v.BookNumber, v.Chapter, v.VerseNo });
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Data Source={Resources.BiblePath}\\{bible}.SQLite3");
        }
    }
}