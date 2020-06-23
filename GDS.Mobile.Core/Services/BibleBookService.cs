using GDS.Core.Data.Mobile;
using GDS.Core.Models;
using GDS.Core.Models.Enums;
using GDS.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GDS.Mobile.Core.Services
{
    public class BibleBookService : IBibleBookService<BibleBook>
    {
        private readonly IRestService _restService;
        private readonly IDataStore<BibleBook> _dataStore;

        public BibleBookService(IRestService restService, IDataStore<BibleBook> dataStore)
        {
            _restService = restService;
            _dataStore = dataStore;
        }

        public async Task<bool> DownloadAsync(BibleVersion bible, BookList book)
        {
            var result = await _restService.Client.For<BibleBook>().Filter(f => f.Version == bible && f.BookCode == book).Expand("*").FindEntryAsync();
            return await _dataStore.UpdateAsync(result, true);
        }

        public async Task<BibleBook> GetAsync(BibleVersion bible, BookList book)
        {
            return await _restService.Client.For<BibleBook>().Filter(x => x.Version == bible && x.BookCode == book).Expand('*').FindEntryAsync();
        }

        public async Task<IEnumerable<BibleBook>> GetAsync(BibleVersion bible)
        {
            return await _restService.Client.For<BibleBook>().Filter(x => x.Version == bible).FindEntriesAsync();
        }

        public async Task<BibleBook> GetAsync(BibleVersion bible, BookList book, int chapter)
        {
            return await _restService.Client.For<BibleBook>().Filter(x => x.Version == bible && x.BookCode == book).Expand(v => v.Verses).FindEntryAsync();
        }
    }
}