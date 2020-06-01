using GDS.Core.Models;
using GDS.Core.Models.Enums;
using GDS.Core.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GDS.Mobile.Core.Services
{
    public class ChapterService : IChapterService<Chapter>
    {
        private readonly IRestService _restService;

        public ChapterService(IRestService restService)
        {
            _restService = restService;
        }

        public async Task<Chapter> GetAsync(BibleVersion bible, BookList book)
        {
            return await _restService.Client.For<Chapter>().Filter(x => x.Version == bible && x.BookCode == book).FindEntryAsync();
        }

        public async Task<IEnumerable<Chapter>> GetAsync(BibleVersion bible)
        {
            return await _restService.Client.For<Chapter>().Filter(x => x.Version == bible).FindEntriesAsync();
        }
    }
}