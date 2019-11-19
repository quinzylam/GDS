using GDS.Core.Models.Bibles;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace GDS.Data.EF.Contexts
{
    public class GDSServerContext : DbContext
    {
        public GDSServerContext(DbContextOptions<GDSServerContext> options)
            : base(options)
        {
        }

        public DbSet<Translation> Translations { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Verse> Verses { get; set; }
    }
}