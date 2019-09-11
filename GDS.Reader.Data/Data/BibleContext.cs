using GDS.Reader.Core.Models;
using GDS.Reader.Core.Models.Bibles;
using GDS.Reader.Core.Models.Enums;
using GDS.Reader.Data.Properties;
using Microsoft.EntityFrameworkCore;

namespace GDS.Reader.Data
{
    public class BibleContext : DbContext
    {
        public BibleContext()
        {
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Verse> Verses { get; set; }
        public DbSet<Info> Info { get; set; }

        public Translations Bible { get; set; } = Translations.KJV;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Verse>().HasKey(v => new { v.BookNumber, v.Chapter, v.VerseNo });
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Data Source={Resources.BiblePath}\\{Bible.ToString()}.SQLite3");
        }
    }
}