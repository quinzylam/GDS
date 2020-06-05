using GDS.Core.Models;
using GDS.Core.Models.Enums;
using GDS.Core.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GDS.Mobile.Core.Services
{
    public class VerseService : IVerseService<Verse>
    {
        private readonly IRestService _restService;

        public VerseService(IRestService restService)
        {
            _restService = restService;
        }

        public async Task<IEnumerable<Verse>> GetAsync(BibleVersion bible, BookList book, int chapter)
        {
            return await _restService.Client.For<Verse>().Expand(c => c.Chapter).Filter(x => x.Chapter.Version == bible && x.Chapter.BookCode == book && x.ChapterNum == chapter).OrderBy(s => s.ChapterNum).ThenBy(v => v.Position).FindEntriesAsync();
        }
    }
}