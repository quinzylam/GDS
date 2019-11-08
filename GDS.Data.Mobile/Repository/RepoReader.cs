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
    public class RepoReader<T> : BaseRepository<T>, IDataReader<T> where T : BaseModel
    {
        public RepoReader(GDSContext context) : base(context)
        {
        }

        public async Task<IQueryable<T>> GetAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(Entities.AsQueryable());
        }

        public async Task<T> GetAsync(int id)
        {
            return await Entities.FindAsync(id);
        }
    }
}