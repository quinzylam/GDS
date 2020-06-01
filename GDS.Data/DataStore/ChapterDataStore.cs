﻿using GDS.Core.Data;
using GDS.Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GDS.Data.DataStore
{
    public class ChapterDataStore : IDataStore<Chapter>
    {
        private readonly Context _ctx;

        public ChapterDataStore(Context ctx)
        {
            _ctx = ctx;
        }

        public IQueryable<Chapter> Get()
        {
            return _ctx.Chapters.AsNoTracking();
        }

        public Chapter Get(Guid id)
        {
            return _ctx.Find<Chapter>(id);
        }
    }
}