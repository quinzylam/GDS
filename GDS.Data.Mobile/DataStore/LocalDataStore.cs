using GDS.Core.Data;
using GDS.Core.Models;
using GDS.Core.Models.Studies;
using GDS.Core.Models.System;
using GDS.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GDS.Data.Mobile.DataStore
{
    public class LocalDataStore<T> : ILocalStore<T> where T : BaseModel
    {
        public LocalDataStore()
        {
        }

        public Task<bool> CreateAsync(T model)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<T> GetAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<IQueryable<T>> GetAsync(bool forceRefresh = false)
        {
            throw new NotImplementedException();
        }

        public Task<T> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(T model)
        {
            throw new NotImplementedException();
        }
    }
}