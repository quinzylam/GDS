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
    public class BibleDataStore : IDataStore<Bible>
    {
        private readonly IMobileContext _ctx;
        private readonly IMapper _mapper;

        public BibleDataStore(IMobileContext ctx)
        {
            _ctx = ctx;
            _mapper = new Mapper(_ctx.MapConfig);
        }

        public bool Any()
        {
            return Task.Run(async () => await _ctx.Conn.Table<BibleDbo>().CountAsync()).Result > 0;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var result = await _ctx.Conn.DeleteAsync<BibleDbo>(id);
            return result > 0;
        }

        public async Task<Bible> GetAsync(Guid id)
        {
            var result = await _ctx.Conn.FindAsync<BibleDbo>(id);
            return _mapper.Map<Bible>(result);
        }

        public async Task<IEnumerable<Bible>> GetAsync()
        {
            var result = await _ctx.Conn.Table<BibleDbo>().ToListAsync();
            return _mapper.ProjectTo<Bible>(result.AsQueryable());
        }

        public async Task<bool> InsertAsync(Bible item)
        {
            var result = await _ctx.Conn.InsertAsync(_mapper.Map<BibleDbo>(item));
            return result > 0;
        }

        public async Task<bool> UpdateAsync(Bible item, bool forceRefresh = false)
        {
            int result;
            var dbobj = _mapper.Map<BibleDbo>(item);
            if (!forceRefresh)
                result = await _ctx.Conn.UpdateAsync(dbobj);
            else
            {
                result = await _ctx.Conn.InsertOrReplaceAsync(dbobj);
                if (item.BibleBooks.Any())
                {
                    foreach (var book in item.BibleBooks)
                    {
                        result += await _ctx.Conn.InsertOrReplaceAsync(_mapper.Map<BibleBookDbo>(book));
                        if (book.Book != null)
                            result += await _ctx.Conn.InsertOrReplaceAsync(_mapper.Map<BookDbo>(book.Book));
                        if (book.Verses.Any())
                            foreach (var verse in book.Verses)
                                result += await _ctx.Conn.InsertOrReplaceAsync(_mapper.Map<VerseDbo>(verse));
                    }
                }
            }

            return result > 0;
        }
    }
}