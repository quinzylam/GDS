using System.Linq;
using GDS.Reader.Core.Models;
using GDS.Reader.Core.Models.Bibles;
using GDS.Reader.Core.Models.Enums;

namespace GDS.Reader.Core.Services
{
    public interface IBibleService
    {
        Translations Translation { get; set; }

        IQueryable<Info> GetInfo();

        Info GetInfo(string key);

        Book GetBook(int id);

        IQueryable<Book> GetBooks();

        Verse GetVerse(int bookNo, int chapter, int verseNumber);

        IQueryable<Verse> GetVerses(int bookNo, int chapter, int? fromVerse = null, int? toVerse = null);
    }
}