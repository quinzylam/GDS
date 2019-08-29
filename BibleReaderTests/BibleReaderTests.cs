using BibleReader;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace BibleReaderTests
{
    [TestClass]
    public class BibleReaderTests
    {
        private static IReader _reader;

        [ClassInitialize]
        public static void InitializeTests(TestContext ctx)
        {
            _reader = new Reader("KJV+");
        }

        [TestMethod]
        public void GetVerseTest()
        {
            var result = _reader.GetVerse(10, 1, 1);
            Assert.IsNotNull(result, "Results are null");
            Assert.AreEqual("<pb/>In the beginning<S>7225</S> God<S>430</S> created<S>1254</S> <S>853</S> the heaven<S>8064</S> and the earth.<S>776</S>", result.Text);
        }

        [TestMethod]
        public void GetBooksTest()
        {
            var result = _reader.GetBooks();
            Assert.IsNotNull(result, "Results are null");
        }

        [TestMethod]
        public void GetBookTest()
        {
            var result = _reader.GetBook(10);
            Assert.IsNotNull(result, "Results are null");
        }

        [TestMethod]
        public void GetVersesTest()
        {
            var result = _reader.GetVerses(10, 1);
            Assert.IsNotNull(result, "Results are null");
        }

        [TestMethod]
        public void GetDictionaryByStrongsTest()
        {
            var result = _reader.GetDictionaryByStrongs(10);
            Assert.IsNotNull(result, "Results are null");
        }

        [TestMethod]
        public void GetVerseBreakTest()
        {
            var verses = _reader.GetVerses(10, 1);
            var result = _reader.GetVerseBreak(verses);
            Assert.IsNotNull(result, "Results are null");
            Assert.AreEqual("el-o-heem'", result.ToList()[1].Pronunciation);
        }
    }
}