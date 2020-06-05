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
    public class KJVAEService
    {
        private readonly Repository _repo;
        private IEnumerable<BibleBook> bibleBooks;
        private IEnumerable<Verse> verses;
        private readonly Bible _bible;

        public KJVAEService(Bible bible, IEnumerable<Book> books)
        {
            _bible = bible;
            Books = books;
            _repo = new Repository();
        }

        public IEnumerable<BibleBook> BibleBooks
        {
            get
            {
                if (bibleBooks == null)
                    GetBibleBooks();
                return bibleBooks;
            }
            set => bibleBooks = value;
        }

        private void GetBibleBooks()
        {
            if (Books == null || _bible == null)
                return;

            if (_repo.Connection.Table<Models.Chapter>().Any())
                BibleBooks = _repo.Connection.Table<Models.Chapter>().Select(x => new BibleBook
                {
                    Id = Guid.NewGuid(),
                    LocalId = x.Id,
                    Book = Books.FirstOrDefault(b => b.Title == x.Title || (b.NTitle ?? string.Empty).Contains(x.Title)),
                    BookId = Books.FirstOrDefault(b => b.Title == x.Title || (b.NTitle ?? string.Empty).Contains(x.Title))?.Id ?? default,
                    BookCode = Books.FirstOrDefault(b => b.Title == x.Title || (b.NTitle ?? string.Empty).Contains(x.Title)).Code,
                    BibleId = _bible.Id,
                    Version = BibleVersion.KJVAE,
                    Num = x.NumOfChapters
                }).ToList();
        }

        public IEnumerable<Verse> Verses
        {
            get
            {
                if (verses == null)
                    GetVerses();
                return verses;
            }
            set => verses = value;
        }

        public IEnumerable<Book> Books { get; }

        private void GetVerses()
        {
            if (BibleBooks == null)
                return;
            verses = _repo.Connection.Table<Models.Verse>().Select(x => new Verse
            {
                Id = Guid.NewGuid(),
                LocalId = x.Id,
                ChapterId = BibleBooks.FirstOrDefault(c => c.LocalId == x.ChapterId).Id,
                ChapterNum = x.ChapterNum,
                Position = x.Position,
                Text = x.Text,
            });
        }
    }
}