using GDS.Core.Data;
using GDS.Core.Models;
using GDS.Core.Models.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GDS.Data.DataStore
{
    public class BibleDataStore : IDataStore<Bible>
    {
        private readonly Context _ctx;

        public BibleDataStore(Context context)
        {
            _ctx = context;
        }

        public IQueryable<Bible> Get()
        {
            return _ctx.Bibles.AsNoTracking();
        }

        public Bible Get(Guid id)
        {
            return _ctx.Find<Bible>(id);
        }
    }
}