using AutoMapper;
using AutoMapper.QueryableExtensions;
using GDS.Core.Data;
using GDS.Core.Models;
using GDS.Data.Mobile.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GDS.Data.Mobile.DataStores
{
    public class ChapterDataStore : IMobileDataStore<Chapter>
    {
        private readonly IMobileContext _ctx;
        private readonly IMapper _mapper;

        public ChapterDataStore(IMobileContext ctx)
        {
            _ctx = ctx;
            _mapper = new Mapper(ctx.MapConfig);
        }

        public void Delete(object id)
        {
            _ctx.Conn.Delete<ChapterDbo>(id);
        }

        public IQueryable<Chapter> Get()
        {
            return _ctx.Conn.Table<ChapterDbo>().AsQueryable().ProjectTo<Chapter>(_ctx.MapConfig);
        }

        public Chapter Get(object id)
        {
            return _mapper.Map<Chapter>(_ctx.Conn.Find<ChapterDbo>(id));
        }

        public void Insert(Chapter model)
        {
            var dbobj = _mapper.Map<ChapterDbo>(model);
            _ctx.Conn.Insert(dbobj);
        }

        public bool Save(Chapter model)
        {
            if (!_ctx.Conn.Table<ChapterDbo>().Any(x => x.Id == model.Id))
            {
                Insert(model);
                return true;
            }
            Update(model);
            return default;
        }

        public void Update(Chapter model)
        {
            var dbobj = _mapper.Map<ChapterDbo>(model);
            _ctx.Conn.Update(dbobj);
        }
    }
}