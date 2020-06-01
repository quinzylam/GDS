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
        private IEnumerable<Chapter> chapters;
        private IEnumerable<Verse> verses;
        private readonly Bible _bible;

        public KJVAEService(Bible bible, IEnumerable<Book> books)
        {
            _bible = bible;
            Books = books;
            _repo = new Repository();
        }

        public IEnumerable<Chapter> Chapters
        {
            get
            {
                if (chapters == null)
                    GetChapters();
                return chapters;
            }
            set => chapters = value;
        }

        private void GetChapters()
        {
            if (Books == null || _bible == null)
                return;

            if (_repo.Connection.Table<Models.Chapter>().Any())
                chapters = _repo.Connection.Table<Models.Chapter>().Select(x => new Chapter
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
            if (Chapters == null)
                return;
            verses = _repo.Connection.Table<Models.Verse>().Select(x => new Verse
            {
                Id = Guid.NewGuid(),
                LocalId = x.Id,
                ChapterId = Chapters.FirstOrDefault(c => c.LocalId == x.ChapterId).Id,
                ChapterNum = x.ChapterNum,
                Position = x.Position,
                Text = x.Text,
            });
        }
    }
}