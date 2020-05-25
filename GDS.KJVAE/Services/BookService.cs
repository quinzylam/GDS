using GDS.Core.Helpers;
using GDS.Core.Models;
using GDS.Core.Models.Enums;
using GDS.Data.Seed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GDS.KJVAE.Services
{
    public class BookService
    {
        private readonly Repository _repo;
        private IEnumerable<Chapter> chapters;
        private IEnumerable<Verse> verses;
        private IEnumerable<Book> books;

        public BookService()
        {
            _repo = new Repository();
        }

        public Core.Models.Bible Bible { get => Seed.Bibles.FirstOrDefault(x => x.Code == BibleVersion.KJVAE); }

        public IEnumerable<Book> Books
        {
            get
            {
                if (books == null)
                    books = Seed.Books;
                return books;
            }

            set => books = value;
        }

        public IEnumerable<Chapter> Chapters
        {
            get
            {
                if (chapters == null)
                    GetChapters();
                return chapters;
            }
        }

        private void GetChapters()
        {
            chapters = _repo.Connection.Table<Models.Chapter>().Select(x => new Chapter { Id = Guid.NewGuid(), LocalId = x.Id, BookId = Books.FirstOrDefault(b => b.Title == x.Title || b.NTitle.Contains(x.Title)).Id, Version = BibleVersion.KJVAE, Num = x.NumOfChapters }).ToList();
        }

        public IEnumerable<Verse> Verses
        {
            get
            {
                if (verses == null)
                    verses = _repo.Connection.Table<Models.Verse>().Select(x => new Verse
                    {
                        Id = Guid.NewGuid(),
                        ChapterId = Chapters.FirstOrDefault(c => c.LocalId == x.ChapterId).Id,
                        ChapterNum = x.ChapterNum,
                        Position = x.Position,
                        Text = x.Text,
                    });
                return verses;
            }
        }
    }
}