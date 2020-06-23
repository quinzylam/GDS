using GDS.Bibles.Core.Services;
using GDS.Core.Helpers;
using GDS.Core.Models;
using GDS.Core.Models.Enums;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace GDS.NKJV.Services
{
    public class NKJVService : IBibleService
    {
        private Bible _bible;
        private IEnumerable<BibleBook> _bibleBooks;
        private IEnumerable<Verse> _verses;
        private IEnumerable<Heading> _headings;

        public IEnumerable<Book> Books { get; }

        public IEnumerable<BibleBook> BibleBooks
        {
            get => GetBibleBooks();
            set => _bibleBooks = value;
        }

        private IEnumerable<BibleBook> GetBibleBooks()
        {
            if (_bibleBooks != null)
                return _bibleBooks;

            if (Books == null || Bible == null)
                return null;

            if (_repo.Connection.Table<Bibles.Core.Models.Book>().Any())
                _bibleBooks = _repo.Connection.Table<Bibles.Core.Models.Book>().Select(x => new BibleBook
                {
                    Id = Guid.NewGuid(),
                    LocalId = x.BookNumber,
                    Book = Books.FirstOrDefault(b => b.ShortTitle.Equals(x.ShortName) | (b.NTitle ?? string.Empty).Split(',').Contains(x.ShortName)),
                    BookId = Books.FirstOrDefault(b => b.ShortTitle.Equals(x.ShortName) | (b.NTitle ?? string.Empty).Split(',').Contains(x.ShortName))?.Id ?? default,
                    BookCode = Books.FirstOrDefault(b => b.ShortTitle.Equals(x.ShortName) | (b.NTitle ?? string.Empty).Split(',').Contains(x.ShortName))?.Code,
                    BibleId = Bible.Id,
                    Version = BibleVersion.NKJV,
                    Num = _repo.Connection.Table<Bibles.Core.Models.Verse>().Where(w => w.BookNumber == x.BookNumber).Select(s => s.Chapter).Distinct().Count()
                }).ToList();

            Debug.Assert(_bibleBooks.All(x => x.Book != null), $"Missing books {string.Join(",", _bibleBooks.Where(x => x.Book == null).Select(s => s.LocalId.ToString()))}");

            return _bibleBooks;
        }

        public IEnumerable<Verse> Verses { get => GetVerses(); set => throw new NotImplementedException(); }

        private IEnumerable<Verse> GetVerses()
        {
            if (BibleBooks == null)
                return null;

            _verses = _repo.Connection.Table<Bibles.Core.Models.Verse>().Select(x => new Verse
            {
                Id = Guid.NewGuid(),
                LocalId = int.Parse(string.Concat(string.Format("{0:000}", x.BookNumber), string.Format("{0:000}", x.Chapter), string.Format("{0:000}", x.VerseNo))),
                HeadingId = Headings.FirstOrDefault(f => f.LocalId == int.Parse(string.Concat(string.Format("{0:000}", x.BookNumber), string.Format("{0:000}", x.Chapter), string.Format("{0:000}", x.VerseNo))))?.Id,
                BibleBookId = BibleBooks.FirstOrDefault(c => c.LocalId == x.BookNumber).Id,
                ChapterNum = x.Chapter,
                Position = x.VerseNo,
                Text = x.Text,
            });
            return _verses;
        }

        public Bible Bible { get => GetBible(); }
        public IEnumerable<Heading> Headings { get => GetHeadings(); set => _headings = value; }

        private IEnumerable<Heading> GetHeadings()
        {
            if (_headings != null)
                return _headings;
            if (BibleBooks == null)
                return null;

            var result = _repo.Connection.Table<Bibles.Core.Models.Story>().ToList();

            _headings = _repo.Connection.Table<Bibles.Core.Models.Story>().Select(x => new Heading
            {
                Id = Guid.NewGuid(),
                BookId = BibleBooks.First(f => f.LocalId == x.BookNo).BookId,
                LocalId = int.Parse(string.Concat(string.Format("{0:000}", x.BookNo), string.Format("{0:000}", x.Chapter), string.Format("{0:000}", x.Verse))),
                Chapter = x.Chapter,
                Position = x.Verse,
                Order = x.Order,
                Title = x.Title,
            });

            Debug.Assert(_headings.All(x => x.LocalId != 0), $"{_repo.Connection.Table<Bibles.Core.Models.Story>().Select(x => string.Concat(string.Format("{0:000}", x.BookNo), string.Format("{0:000}", x.Chapter), string.Format("{0:000}", x.Verse))).FirstOrDefault()}");
            return _headings;
        }

        private Bible GetBible()
        {
            _bible = new Bible
            {
                Id = _bible?.Id ?? Guid.NewGuid(),
                LocalId = (int)BibleVersion.NKJV,
                Code = BibleVersion.NKJV,
                Title = EnumHelper.GetDescription(BibleVersion.NKJV),
                NumOfBooks = _repo.Connection.Table<Bibles.Core.Models.Book>().Count(),
                Description = _repo.Connection.Table<Bibles.Core.Models.Info>().FirstOrDefault(x => x.Name == "description").Value,
                Copyright = _repo.Connection.Table<Bibles.Core.Models.Info>().FirstOrDefault(x => x.Name == "detailed_info").Value,
            };
            return _bible;
        }

        private readonly Repository _repo;

        public NKJVService(IEnumerable<Book> books, Bible bible)
        {
            _bible = bible;
            Books = books;
            _repo = new Repository();
        }
    }
}