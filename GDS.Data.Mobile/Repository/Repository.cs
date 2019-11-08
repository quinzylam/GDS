using GDS.Core.Data;
using GDS.Core.Models;
using GDS.Data.Mobile.Contexts;
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
            model.CreatedOn = DateTime.UtcNow;
            Entities.Add(model);
            var rows = await context.SaveChangesAsync();
            return rows > 0;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var dbobj = await Entities.FindAsync(id);
            var result = dbobj != null;
            Entities.Remove(dbobj);
            return result;
        }

        public async Task<bool> UpdateAsync(T model)
        {
            model.ModifiedOn = DateTime.UtcNow;
            context.Update(model);
            var rows = await context.SaveChangesAsync();
            return rows > 0;
        }
    }
}