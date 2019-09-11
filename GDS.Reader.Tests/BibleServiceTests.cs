using GDS.Reader.Core.Services;
using GDS.Reader.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GDS.Reader.Tests
{
    [TestClass]
    public class BibleServiceTests
    {
        private static IBibleService _service;

        [ClassInitialize]
        public static void InitializeTests(TestContext ctx)
        {
            _service = new BibleService();
        }

        [TestMethod]
        public void ChangeTranslationTest()
        {
            _service.Translation = Core.Models.Enums.Translations.AFR;
            var result = _service.GetVerse(10, 1, 1);
            Assert.IsNotNull(result, $"Results are null after translation {_service.Translation.ToString()}");

            _service.Translation = Core.Models.Enums.Translations.AMP;
            result = _service.GetVerse(10, 1, 1);
            Assert.IsNotNull(result, $"Results are null after translation {_service.Translation.ToString()}");

            _service.Translation = Core.Models.Enums.Translations.AMPC;
            result = _service.GetVerse(10, 1, 1);
            Assert.IsNotNull(result, $"Results are null after translation {_service.Translation.ToString()}");

            _service.Translation = Core.Models.Enums.Translations.CJB;
            result = _service.GetVerse(10, 1, 1);
            Assert.IsNotNull(result, $"Results are null after translation {_service.Translation.ToString()}");

            _service.Translation = Core.Models.Enums.Translations.KJV1769;
            result = _service.GetVerse(10, 1, 1);
            Assert.IsNotNull(result, $"Results are null after translation {_service.Translation.ToString()}");

            _service.Translation = Core.Models.Enums.Translations.KJVA;
            result = _service.GetVerse(10, 1, 1);
            Assert.IsNotNull(result, $"Results are null after translation {_service.Translation.ToString()}");

            _service.Translation = Core.Models.Enums.Translations.KJV;
            result = _service.GetVerse(10, 1, 1);
            Assert.IsNotNull(result, $"Results are null after translation {_service.Translation.ToString()}");
        }

        [TestMethod]
        public void GetVerseTest()
        {
            var result = _service.GetVerse(10, 1, 1);
            Assert.IsNotNull(result, "Results are null");
            Assert.AreEqual("<pb/>In the beginning<S>7225</S> God<S>430</S> created<S>1254</S> <S>853</S> the heaven<S>8064</S> and the earth.<S>776</S>", result.Text);
        }

        [TestMethod]
        public void GetBooksTest()
        {
            var result = _service.GetBooks();
            Assert.IsNotNull(result, "Results are null");
        }

        [TestMethod]
        public void GetBookTest()
        {
            var result = _service.GetBook(10);
            Assert.IsNotNull(result, "Results are null");
        }

        [TestMethod]
        public void GetVersesTest()
        {
            var result = _service.GetVerses(10, 1);
            Assert.IsNotNull(result, "Results are null");
        }
    }
}