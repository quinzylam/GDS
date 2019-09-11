using GDS.Reader.Core.Models.Commentaries;
using GDS.Reader.Data.Properties;
using Microsoft.EntityFrameworkCore;

namespace GDS.Reader.Data
{
    public class CommentaryContext : DbContext
    {
        private readonly string _commentary = "jasher";

        public CommentaryContext(string commentary) => _commentary = commentary;

        public DbSet<Chapter> Chapters { get; set; }
        public DbSet<Comment> Comments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseSqlite($"Data Source = {Resources.CommentariesPath}\\{_commentary}.SQLite3");
    }
}