using System.Collections.Generic;
using System.Linq;
using BibleReader.Models;
using BibleReader.Models.Bible;

namespace BibleReader.Services
{
    public interface IBibleService
    {
        IQueryable<Info> GetInfo();

        Info GetInfo(string key);

        Book GetBook(int id);

        IQueryable<Book> GetBooks();

        Verse GetVerse(int bookNo, int chapter, int verseNumber);

        IQueryable<Verse> GetVerses(int bookNo, int chapter, int? fromVerse = null, int? toVerse = null);
    }
}