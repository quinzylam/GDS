using GDS.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GDS.Core.Data.DataStore
{
    public class MockDataStore<T> : IDataStore<T> where T : BaseModel
    {
        private readonly List<T> items;
        private int localId = 0;

        public MockDataStore()
        {
            items = new List<T>();
        }

        public async Task<bool> CreateAsync(T model)
        {
            model.Id = localId++;
            model.Gid = Guid.NewGuid().ToString();
            model.CreatedOn = DateTime.UtcNow;
            items.Add(model);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteAsync(string id)
        {
            var oldItem = items.Where(arg => arg.Gid == id).FirstOrDefault();
            items.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<T> GetAsync(string id)
        {
            return await Task.FromResult(items.FirstOrDefault(x => x.Gid == id));
        }

        public async Task<IQueryable<T>> GetAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items.AsQueryable());
        }

        public async Task<T> GetAsync(int id)
        {
            return await Task.FromResult(items.FirstOrDefault(x => x.Id == id));
        }

        public async Task<bool> UpdateAsync(T model)
        {
            var oldItem = items.Where(arg => arg.Id == model.Id).FirstOrDefault();
            items.Remove(oldItem);
            items.Add(model);

            return await Task.FromResult(true);
        }
    }
}