using GDS.Core.Data;
using GDS.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GDS.MockFactory.Data.DataStore
{
    public class MockDataReader<T> : IDataReader<T> where T : IReaderModel
    {
        private readonly IEnumerable<T> _items;

        public MockDataReader(IEnumerable<T> items)
        {
            _items = items;
        }

        public IQueryable<T> Get()
        {
            return _items.AsQueryable();
        }

        public T Get(int id)
        {
            return _items.FirstOrDefault(x => x.Id == id);
        }
    }
}