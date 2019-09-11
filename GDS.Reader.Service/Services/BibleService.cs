using GDS.Reader.Core.Models;
using GDS.Reader.Core.Models.Bibles;
using GDS.Reader.Core.Models.Enums;
using GDS.Reader.Core.Services;
using GDS.Reader.Data;
using System.Diagnostics.Contracts;
using System.Linq;

namespace GDS.Reader.Services
{
    public class BibleService : IBibleService
    {
        private BibleContext _ctx;

        public BibleService()
        {
            _ctx = new BibleContext();
        }

        public IQueryable<Info> GetInfo()
        {
            return _ctx.Info.AsQueryable();
        }

        public Info GetInfo(string name)
        {
            return _ctx.Info.Find(name);
        }

        public Verse GetVerse(int bookNo, int chapter, int verseNumber)
        {
            Contract.Ensures(Contract.Result<Verse>() != null);
            var result = _ctx.Verses.FirstOrDefault(v => v.BookNumber == bookNo && v.Chapter == chapter & v.VerseNo == verseNumber);

            return result;
        }

        public IQueryable<Verse> GetVerses(int bookNo, int chapter, int? fromVerse = null, int? toVerse = null)
        {
            Contract.Ensures(Contract.Result<Verse>() != null);
            var result = _ctx.Verses.Where(v => v.BookNumber == bookNo && v.Chapter == chapter);
            if (fromVerse != null || toVerse != null)
                result = result.Where(v => v.VerseNo >= (fromVerse ?? 1) && v.VerseNo <= (toVerse ?? result.Last().VerseNo)).AsQueryable();
            return result;
        }

        public IQueryable<Book> GetBooks()
        {
            var result = _ctx.Books.AsQueryable();
            return result;
        }

        public Book GetBook(int id)
        {
            var result = _ctx.Books.FirstOrDefault(b => b.BookNumber == id);
            return result;
        }

        public Translations Translation { get => _ctx.Bible; set => _ctx.Bible = value; }
    }
}