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
    public class RepoReader<T> : BaseRepository<T>, IDataReader<T> where T : BaseReader
    {
        public RepoReader(GDSContext context) : base(context)
        {
        }

        public IQueryable<T> Get()
        {
            return Entities.AsQueryable();
        }

        public T Get(int id)
        {
            return Entities.Find(id);
        }
    }
}