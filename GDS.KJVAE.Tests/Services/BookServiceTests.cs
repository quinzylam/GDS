using NUnit.Framework;
using GDS.KJVAE.Services;
using System;
using System.Collections.Generic;
using System.Text;

using GDS.Data.Seed;
using System.Linq;

namespace GDS.KJVAE.Services.Tests
{
    [TestFixture()]
    public class BookServiceTests
    {
        private BookService _service;

        [SetUp]
        public void SetUp()
        {
            _service = new BookService();
        }

        [Test()]
        public void GetChaptersTest()
        {
            var bible = Seed.Bibles.FirstOrDefault(x => x.Code == Core.Models.Enums.BibleVersion.KJVAE);

            var result = _service.Chapters;
            Assert.AreEqual(bible.NumOfBooks, result.Count());
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