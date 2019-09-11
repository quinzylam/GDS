using GDS.Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GDS.Data.EF.Contexts
{
    public class GDSContext : DbContext
    {
        public GDSContext(DbContextOptions<GDSContext> options) : base(options)
        {
        }

        public virtual DbSet<ObjectModel> Objects { get; set; }
        public virtual DbSet<ActionModel> Actions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public override int SaveChanges()
        {
            AddAuditInfo();
            return base.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            AddAuditInfo();
            await base.SaveChangesAsync();
        }

        private void AddAuditInfo()
        {
            var entries = ChangeTracker.Entries().Where(x => x.Entity is BaseEntity && (x.State == EntityState.Added || x.State == EntityState.Modified));
            foreach (var entry in entries)
            {
                if (entry.State == EntityState.Added)
                {
                    ((BaseEntity)entry.Entity).CreatedOn = DateTime.UtcNow;
                    ((BaseEntity)entry.Entity).CreatedBy = ((BaseEntity)entry.Entity).Username;
                }
                ((BaseEntity)entry.Entity).ModifiedOn = DateTime.UtcNow;
                ((BaseEntity)entry.Entity).ModifiedBy = ((BaseEntity)entry.Entity).Username;
            }
        }
    }
}