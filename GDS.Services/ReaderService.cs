using BibleReader;
using BibleReader.Models;
using BibleReader.Views;
using System;
using System.Collections.Generic;

namespace GDS.Services
{
    public class ReaderService
    {
        private readonly IReader _reader;

        public ReaderService(IReader reader)
        {
            _reader = reader;
        }

        public Book GetBook(int id)
        {
            return _reader.GetBook(id);
        }

        public IEnumerable<Book> GetBooks()
        {
            return _reader.GetBooks();
        }

        public Dictionary GetDictionaryByStrongs(int strongsNo)
        {
            return _reader.GetDictionaryByStrongs(strongsNo);
        }

        public Verse GetVerse(int chapter, int verseNumber)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<BreakView> GetVerseBreak(IEnumerable<Verse> verses)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Verse> GetVerses(int chapter, int? fromVerse = null, int? toVerse = null)
        {
            throw new NotImplementedException();
        }
    }
}