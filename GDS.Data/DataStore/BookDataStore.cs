using GDS.Core.Data;
using GDS.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GDS.Data.DataStore
{
    public class BookDataStore : IDataStore<Book>
    {
        private readonly Context _ctx;

        public BookDataStore(Context context)
        {
            _ctx = context;
        }

        public IQueryable<Book> Get()
        {
            return _ctx.Books;
        }
    }
}