using BibleReader.Data;
using BibleReader.Models;
using BibleReader.Models.Bible;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;

namespace BibleReader.Services
{
    public class BibleService : IBibleService
    {
        private readonly BibleContext _ctx;

        public BibleService(string translation)
        {
            _ctx = new BibleContext(translation);
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
            var result = _ctx.Books.FirstOrDefault(b => b.BookNo == id);
            return result;
        }
    }
}