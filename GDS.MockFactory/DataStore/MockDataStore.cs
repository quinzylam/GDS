using GDS.Core.Data;
using GDS.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GDS.MockFactory.Data.DataStore
{
    public class MockDataStore<T> : MockDataReader<T>, IDataStore<T> where T : IModel
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

        public async Task<IEnumerable<T>> GetAsync()
        {
            return await Task.FromResult(_items.ToList());
        }

        public async Task<int> SaveAsync(T model)
        {
            if (model != null)
            {
                if (model.Id == 0)
                    await AddAsync(model);
                else
                    await UpdateAsync(model);
                return 1;
            }
            return 0;
        }

        public async Task<bool> UpdateAsync(T model)
        {
            var oldItem = _items.Where(arg => arg.Id == model.Id).FirstOrDefault();
            _items.Remove(oldItem);
            _items.Add(model);

            return await Task.FromResult(true);
        }

        public async Task<T> GetAsync(int id)
        {
            return await Task.FromResult(_items.FirstOrDefault(x => x.Id == id));
        }
    }
}