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
    public class BookService : IBookService<Book>
    {
        private readonly IRestService _restService;

        public BookService(IRestService restService)
        {
            _restService = restService;
        }

        public async Task<IEnumerable<Book>> GetAsync()
        {
            return await _restService.Client.For<Book>().FindEntriesAsync();
        }

        public async Task<Book> GetAsync(BookList code)
        {
            return await _restService.Client.For<Book>().Filter(x => x.Code == code).FindEntryAsync();
        }

        public async Task<IEnumerable<Book>> GetBooksForVersionAsync(BibleVersion version)
        {
            return await _restService.Client.For<Book>().Expand(e => e.BibleBooks).Filter(f => f.BibleBooks.Any(c => c.Version == version)).OrderBy(o => o.Code).FindEntriesAsync();
        }
    }
}