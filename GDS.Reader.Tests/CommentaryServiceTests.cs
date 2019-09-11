using GDS.Reader.Core.Services;
using GDS.Reader.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GDS.Reader.Tests
{
    [TestClass]
    public class CommentaryServiceTests
    {
        private static ICommentaryService _service;

        [ClassInitialize]
        public static void InitializeTests(TestContext ctx)
        {
            _service = new CommentaryService("jasher");
        }

        [TestMethod]
        public void GetChaptersTests()
        {
            var result = _service.GetChapters();
            Assert.IsNotNull(result, "Results are null");
        }

        [TestMethod]
        public void GetCommentsTests()
        {
            var result = _service.GetComments();
            Assert.IsNotNull(result, "Results are null");
        }
    }
}