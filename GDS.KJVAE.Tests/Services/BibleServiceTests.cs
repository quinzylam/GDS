using NUnit.Framework;
using GDS.KJVAE.Services;
using System;
using System.Collections.Generic;
using System.Text;

using GDS.Data;
using System.Linq;

namespace GDS.KJVAE.Services.Tests
{
    [TestFixture()]
    public class BibleServiceTests
    {
        private KJVAEService _service;

        [SetUp]
        public void SetUp()
        {
            _service = new KJVAEService(Seed.Bibles.FirstOrDefault(x => x.Code == Core.Models.Enums.BibleVersion.KJVAE), Seed.Books);
        }

        [Test()]
        public void GetChaptersTest()
        {
            var bible = Seed.Bibles.FirstOrDefault(x => x.Code == Core.Models.Enums.BibleVersion.KJVAE);

            var result = _service.BibleBooks;
            Assert.AreEqual(bible.NumOfBooks, result.Count());
            Assert.IsTrue(result.Count(x => _service.Books.Select(b => b.Id).Contains(x.BookId)) > 1);
            Assert.AreEqual(bible.NumOfBooks, result.Select(x => x.BookId).Distinct().Count(), $"The following Books Are Missing {string.Join(',', _service.Books.Where(x => (x.Section == Core.Models.Enums.Section.OldTestiment || x.Section == Core.Models.Enums.Section.NewTestiment || x.Section == Core.Models.Enums.Section.Apochropha || x.Section == Core.Models.Enums.Section.Extended) && !result.Select(b => b.BookId).Contains(x.Id)).Select(x => x.Title))}, the following was not found {string.Join(',', result.Where(x => !_service.Books.Select(b => b.Id).Contains(x.BookId)).Select(x => x.LocalId))}");
        }

        [Test()]
        public void GetVersesTest()
        {
            GetChaptersTest();
            var result = _service.Verses;
            Assert.IsTrue(result.Any());
        }
    }
}