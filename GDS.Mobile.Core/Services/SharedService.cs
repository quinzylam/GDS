using GDS.Core.Models;
using GDS.Core.Models.Enums;
using GDS.Core.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace GDS.Mobile.Core.Services
{
    public class SharedService : ISharedService
    {
        private readonly IBookService<Book> _bookService;

        public SharedService(IBookService<Book> bookService)
        {
            _bookService = bookService;
        }

        public Bible Bible { get; set; }
        public BibleVersion Version { get => Bible?.Code ?? BibleVersion.KJVAE; }
        public Book Book { get; set; }
        public BookList BookCode { get => Book?.Code ?? BookList.Genesis; }
        public BibleBook Chapter { get; set; }
        public int ChapterNo { get; set; } = 1;
        public Verse Verse { get; set; }
        public Verse ToVerse { get; set; }
        public int Position { get => Verse?.Position ?? 1; }

        public async Task<string> GetTitleAsync()
        {
            if (Book == null)
                Book = await _bookService.GetAsync(BookCode);
            return $"{Book.Title} {ChapterNo} {Version.ToString()}";
        }

        public async Task<string> GetReferenceAsync(bool includeVersion = false)
        {
            if (Book == null)
                Book = await _bookService.GetAsync(BookCode);

            string reference = $"{Book.ShortTitle} {ChapterNo}";
            if (Verse != null)
                reference += string.Concat(":", Position);
            if (ToVerse != null)
                reference += string.Concat("-", ToVerse.Position);
            if (includeVersion)
                reference += string.Concat(" ", Version.ToString());
            return reference;
        }

        public async Task<IEnumerable<Book>> GetCurrentBooks()
        {
            return await _bookService.GetBooksForVersionAsync(Version);
        }
    }
}