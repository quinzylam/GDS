using GDS.Bibles.Core.Services;
using GDS.Core.Helpers;
using GDS.Core.Models;
using GDS.Core.Models.Enums;
using GDS.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GDS.KJVAE.Services
{
    public class KJVAEService : IBibleService
    {
        private readonly Repository _repo;
        private IEnumerable<BibleBook> _bibleBooks;
        private IEnumerable<Verse> _verses;

        public KJVAEService(Bible bible, IEnumerable<Book> books)
        {
            Bible = bible;
            Books = books;
            _repo = new Repository();
        }

        public IEnumerable<BibleBook> BibleBooks
        {
            get
            {
                if (_bibleBooks == null)
                    GetBibleBooks();
                return _bibleBooks;
            }
            set => _bibleBooks = value;
        }

        private void GetBibleBooks()
        {
            if (Books == null || Bible == null)
                return;

            if (_repo.Connection.Table<Models.Chapter>().Any())
                BibleBooks = _repo.Connection.Table<Models.Chapter>().Select(x => new BibleBook
                {
                    Id = Guid.NewGuid(),
                    LocalId = x.Id,
                    Book = Books.FirstOrDefault(b => b.Title == x.Title || (b.NTitle ?? string.Empty).Contains(x.Title)),
                    BookId = Books.FirstOrDefault(b => b.Title == x.Title || (b.NTitle ?? string.Empty).Contains(x.Title))?.Id ?? default,
                    BookCode = Books.FirstOrDefault(b => b.Title == x.Title || (b.NTitle ?? string.Empty).Contains(x.Title)).Code,
                    BibleId = Bible.Id,
                    Version = BibleVersion.KJVAE,
                    Num = x.NumOfChapters
                }).ToList();
        }

        public IEnumerable<Verse> Verses
        {
            get
            {
                if (_verses == null)
                    GetVerses();
                return _verses;
            }
            set => _verses = value;
        }

        public IEnumerable<Book> Books { get; }

        public Bible Bible { get; }
        public IEnumerable<Heading> Headings { get; set; }

        private void GetVerses()
        {
            if (BibleBooks == null)
                return;
            _verses = _repo.Connection.Table<Models.Verse>().Select(x => new Verse
            {
                Id = Guid.NewGuid(),
                LocalId = x.Id,
                BibleBookId = BibleBooks.First(c => c.LocalId == x.ChapterId).Id,
                ChapterNum = x.ChapterNum,
                Position = x.Position,
                Text = x.Text,
                HeadingId = Headings.FirstOrDefault(f => f.BookId == (BibleBooks.FirstOrDefault(c => c.LocalId == x.Id)?.Id ?? default) && f.Chapter == x.ChapterNum && f.Position == x.Position)?.Id,
            });
        }
    }
}