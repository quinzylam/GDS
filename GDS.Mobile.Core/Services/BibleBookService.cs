﻿using GDS.Core.Models;
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

        public BibleBookService(IRestService restService)
        {
            _restService = restService;
        }

        public async Task<BibleBook> GetAsync(BibleVersion bible, BookList book)
        {
            return await _restService.Client.For<BibleBook>().Filter(x => x.Version == bible && x.BookCode == book).Expand(v => v.Verses).FindEntryAsync();
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