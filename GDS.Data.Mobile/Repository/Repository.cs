using GDS.Core.Data;
using GDS.Core.Models;
using GDS.Data.Mobile.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GDS.Data.Mobile.Repository
{
    public class Repository<T> : RepoReader<T>, IDataStore<T> where T : BaseModel
    {
        public Repository(GDSContext context) : base(context)
        {
        }

        public async Task<bool> AddAsync(T model)
        {
            if (await Entities.AnyAsync(x => x.Name != model.Name))
            {
                model.CreatedOn = DateTime.UtcNow;
                return Entities.Add(model).State == EntityState.Added;
            }
            return false;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var dbobj = await Entities.FindAsync(id);
            if (dbobj == null)
                return false;

            return Entities.Remove(dbobj).State == EntityState.Deleted;
        }

        public async Task<IEnumerable<T>> GetAsync()
        {
            return await Entities.ToListAsync();
        }

        public async Task<T> GetAsync(int id)
        {
            return await Entities.FindAsync(id);
        }

        public async Task<int> SaveAsync(T model = null)
        {
            if (model != null)
            {
                if (model.Id == 0)
                    await AddAsync(model);
                else
                    await UpdateAsync(model);
            }

            return await context.SaveChangesAsync();
        }

        public async Task<bool> UpdateAsync(T model)
        {
            var dbobj = await context.FindAsync<T>(model.Id);
            if (dbobj == null || dbobj.Equals(model))
                return false;

            model.ModifiedOn = DateTime.UtcNow;
            return context.Update(model).State == EntityState.Modified;
        }
    }
}