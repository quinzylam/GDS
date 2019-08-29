using BibleReader.Models;
using BibleReader.Models.Commentaries;
using BibleReader.Properties;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace BibleReader.Data
{
    public class CommentaryContext : DbContext
    {
        private readonly string _commentary = "jasher";

        public CommentaryContext(string commentary)
        {
            _commentary = commentary;
        }

        public DbSet<Chapter> Chapters { get; set; }
        public DbSet<Comment> Comments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Data Source = {Resources.CommentariesPath}\\{_commentary}.SQLite3");
        }
    }
}