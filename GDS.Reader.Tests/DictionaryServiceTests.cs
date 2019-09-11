using GDS.Reader;
using GDS.Reader.Core.Services;
using GDS.Reader.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace GDS.Reader.Tests
{
    [TestClass]
    public class DictionaryServiceTests
    {
        private static IDictionaryService _service;

        [ClassInitialize]
        public static void InitializeTests(TestContext ctx)
        {
            _service = new DictionaryService("SECE.dictionary");
        }

        [TestMethod]
        public void GetReferencesTests()
        {
            var result = _service.GetReferences();
            Assert.IsNotNull(result, "Results are null");
        }

        [TestMethod]
        public void GetReferenceTests()
        {
            var result = _service.GetReference("H10");
            Assert.IsNotNull(result, "Results are null");
        }

        [TestMethod]
        public void GetIndicationsTests()
        {
            var result = _service.GetIndications();
            Assert.IsNotNull(result, "Results are null");
        }
    }
}