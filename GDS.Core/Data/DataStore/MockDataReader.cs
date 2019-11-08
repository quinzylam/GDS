using GDS.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GDS.Core.Data.DataStore
{
    public class MockDataReader<T> : IDataReader<T> where T : BaseReaderModel
    {
        private readonly IEnumerable<T> _items;

        public MockDataReader(IEnumerable<T> items)
        {
            _items = items;
        }

        public async Task<IQueryable<T>> GetAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(_items.AsQueryable());
        }

        public async Task<T> GetAsync(int id)
        {
            return await Task.FromResult(_items.FirstOrDefault(x => x.Id == id));
        }
    }
}