using AutoMapper;
using GDS.Core.Data.Mobile;
using GDS.Core.Models;
using GDS.Data.Mobile.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GDS.Data.Mobile.DataStores
{
    public class BibleBookDataStore : IDataStore<BibleBook>
    {
        private readonly IMobileContext _ctx;
        private readonly IMapper _mapper;

        public BibleBookDataStore(IMobileContext ctx)
        {
            _ctx = ctx;
            _mapper = new Mapper(_ctx.MapConfig);
        }

        public bool Any()
        {
            return Task.Run(async () => await _ctx.Conn.Table<BibleBookDbo>().CountAsync()).Result > 0;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var result = await _ctx.Conn.DeleteAsync<BibleBookDbo>(id);
            return result > 0;
        }

        public async Task<BibleBook> GetAsync(Guid id)
        {
            var result = await _ctx.Conn.FindAsync<BibleBookDbo>(id);
            return _mapper.Map<BibleBook>(result);
        }

        public async Task<IEnumerable<BibleBook>> GetAsync()
        {
            var result = await _ctx.Conn.Table<BibleBookDbo>().ToListAsync();
            return _mapper.ProjectTo<BibleBook>(result.AsQueryable());
        }

        public async Task<bool> InsertAsync(BibleBook item)
        {
            var result = await _ctx.Conn.InsertAsync(_mapper.Map<BibleBookDbo>(item));
            return result > 0;
        }

        public async Task<bool> UpdateAsync(BibleBook item, bool forceRefresh = false)
        {
            int result = 0;
            var dbobj = _mapper.Map<BibleBookDbo>(item);
            if (!forceRefresh)
                result = await _ctx.Conn.UpdateAsync(dbobj);
            else
            {
                if (item.Bible != null)
                    result += await _ctx.Conn.InsertOrReplaceAsync(_mapper.Map<BibleDbo>(item.Bible));

                if (item.Book != null)
                    result += await _ctx.Conn.InsertOrReplaceAsync(_mapper.Map<BookDbo>(item.Book));

                result += await _ctx.Conn.InsertOrReplaceAsync(dbobj);

                if (item.Verses.Any())
                {
                    foreach (var verse in item.Verses)
                        result += await _ctx.Conn.InsertOrReplaceAsync(_mapper.Map<VerseDbo>(verse));
                }
            }

            return result > 0;
        }
    }
}