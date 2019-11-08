using GDS.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GDS.Core.Data.DataStore
{
    public class MockServerDataStore<T> : MockDataStore<T>, IServerDataStore<T> where T : BaseServerModel
    {
        private readonly List<T> _items;
        private int localId = 0;

        public MockServerDataStore(List<T> items) : base(items)
        {
            _items = items;
        }

        public async Task<bool> AddAsync(T model)
        {
            await base.AddAsync(model);
            model.Id = localId++;
            model.Gid = Guid.NewGuid().ToString();
            model.CreatedOn = DateTime.UtcNow;
            _items.Add(model);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteAsync(string id)
        {
            var oldItem = _items.Where(arg => arg.Gid == id).FirstOrDefault();
            _items.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<T> GetAsync(string id)
        {
            return await Task.FromResult(_items.FirstOrDefault(x => x.Gid == id));
        }

        public async Task<IQueryable<T>> GetAsync(bool forceRefresh = false)
        {
            if (forceRefresh)
                return await Task.FromResult(_items.AsQueryable());
            else
                return await base.GetAsync(forceRefresh);
        }

        public async Task<bool> UpdateAsync(T model)
        {
            await base.UpdateAsync(model);
            var oldItem = _items.Where(arg => arg.Gid == model.Gid).FirstOrDefault();
            _items.Remove(oldItem);
            _items.Add(model);

            return await Task.FromResult(true);
        }
    }
}