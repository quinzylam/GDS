using NUnit.Framework;
using GDS.NKJV.Services;
using System;
using System.Collections.Generic;
using System.Text;
using GDS.Data;
using System.Linq;

namespace GDS.NKJV.Services.Tests
{
    [TestFixture()]
    public class NKJVServiceTests
    {
        private NKJVService _service;

        [SetUp]
        public void SetUp()
        {
            _service = new NKJVService(Seed.Books, Seed.Bibles.FirstOrDefault(x => x.Code == Core.Models.Enums.BibleVersion.NKJV));
        }

        [Test()]
        public void GetChaptersTest()
        {
            var bible = _service.Bible;

            var result = _service.BibleBooks;
            Assert.AreEqual(bible.NumOfBooks, result.Count());
            Assert.IsTrue(result.Count(x => _service.Books.Select(b => b.Id).Contains(x.BookId)) > 1);
            Assert.AreEqual(bible.NumOfBooks, result.Select(x => x.BookId).Distinct().Count(), $"The following Books Are Missing {string.Join(',', _service.Books.Where(x => (x.Section == Core.Models.Enums.Section.OldTestiment || x.Section == Core.Models.Enums.Section.NewTestiment) && !result.Select(b => b.BookId).Contains(x.Id)).Select(x => x.Title))}, the following was not found {string.Join(',', result.Where(x => !_service.Books.Select(b => b.Id).Contains(x.BookId)).Select(x => x.LocalId))}");
        }

        [Test()]
        public void GetVersesTest()
        {
            GetChaptersTest();
            var result = _service.Verses;
            Assert.IsTrue(result.Any());
        }

        [Test()]
        public void GetHeadingsTest()
        {
            GetChaptersTest();
            var result = _service.Headings;
            Assert.IsTrue(result.Any());
            Assert.IsFalse(result.Any(x => x.LocalId == 0), $"The following Titels do not have localId: {string.Join(',', result.Where(x => x.LocalId == 0).Select(s => s.Title))}");
        }
    }
}