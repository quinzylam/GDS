using GDS.Bible.Core.Models;
using GDS.Bible.Core.Models.Enums;
using GDS.Bible.Core.Services;
using GDS.Bible.SeedData;
using System;

namespace GDS.Bible.Service
{
    public class BibleService : IBibleService
    {
        private SeedBible _seed;

        public BibleService()
        {
        }

        public Book GetBook(string bookName)
        {
            throw new NotImplementedException();
        }

        public Chapter GetChapter(int id, int? chapterNo)
        {
            throw new NotImplementedException();
        }

        public Translation GetTranslation(BibleVersion version)
        {
            _seed = new SeedBible(version);
            return _seed.GetTranslation(version);
        }

        public Verse GetVerse(int id, int? fromVerse)
        {
            throw new NotImplementedException();
        }
    }
}
