using GDS.Core.Data;
using GDS.Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GDS.Data.DataStore
{
    public class ChapterDataStore : IDataStore<BibleBook>
    {
        private readonly Context _ctx;

        public ChapterDataStore(Context ctx)
        {
            _ctx = ctx;
        }

        public IQueryable<BibleBook> Get()
        {
            return _ctx.BibleBooks.AsNoTracking();
        }

        public BibleBook Get(Guid id)
        {
            return _ctx.Find<BibleBook>(id);
        }
    }
}