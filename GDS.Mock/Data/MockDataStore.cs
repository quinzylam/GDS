using GDS.Core.Data.Mobile;
using GDS.Core.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GDS.Mock.Data
{
    public class MockDataStore<T> : IDataStore<T> where T : ReadModel
    {
        private readonly List<T> items;

        public MockDataStore()
        {
            items = new List<T>();
        }

        public async Task<bool> InsertAsync(T item)
        {
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateAsync(T item)
        {
            var oldItem = items.Where((T arg) => arg.Id == item.Id).FirstOrDefault();
            items.Remove(oldItem);
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var oldItem = items.Where((T arg) => arg.Id == id).FirstOrDefault();
            items.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<T> GetAsync(Guid id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<T>> GetAsync()
        {
            return await Task.FromResult(items);
        }

        public bool Any()
        {
            return items.Any();
        }

        public Task<bool> UpdateAsync(T item, bool forceRefresh)
        {
            throw new NotImplementedException();
        }
    }
}