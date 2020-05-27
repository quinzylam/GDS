using GDS.Core.Data;
using GDS.Core.Models;
using GDS.Core.Services;
using GDS.Data;
using System;
using System.Collections.Generic;

namespace GDS.Services.Core.Services
{
    public class BookService : IBookService<Book>
    {
        private readonly IDataStore<Book> _dataStore;

        public BookService(IDataStore<Book> dataSore)
        {
            _dataStore = dataSore;
        }

        public IEnumerable<Book> Get()
        {
            return _dataStore.Get();
        }
    }
}