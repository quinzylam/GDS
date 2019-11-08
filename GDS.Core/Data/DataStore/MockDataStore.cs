using GDS.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GDS.Core.Data.DataStore
{
    public class MockDataStore<T> : MockDataReader<T>, IDataStore<T> where T : BaseModel
    {
        private readonly List<T> _items;
        private int localId = 0;

        public MockDataStore(List<T> items) : base(items)
        {
            _items = items;
        }

        public async Task<bool> AddAsync(T model)
        {
            model.Id = localId++;
            model.CreatedOn = DateTime.UtcNow;
            _items.Add(model);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var oldItem = _items.Where(arg => arg.Id == id).FirstOrDefault();
            _items.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateAsync(T model)
        {
            var oldItem = _items.Where(arg => arg.Id == model.Id).FirstOrDefault();
            _items.Remove(oldItem);
            _items.Add(model);

            return await Task.FromResult(true);
        }
    }
}