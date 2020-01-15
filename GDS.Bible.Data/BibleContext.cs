using GDS.Bible.Core.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace GDS.Bible.Data
{
    public class BibleContext:DbContext
    {
        public BibleContext (DbContextOptions<BibleContext> options) :base(options)
        {

        }

        public DbSet<Translation> Translation { get; set; }
        public DbSet<Book> Book { get; set; }
        public DbSet<Chapter> Chapter { get; set; }
        public DbSet<Verse> Verse { get; set; }
        public DbSet<BibleDictionary> Dictionary { get; set; }
        public DbSet<MorphologyIndication> MorphologyIndication { get; set; }
        public DbSet<CognateStrongNumber> CognateStrongNumber { get; set; }
    }
}
