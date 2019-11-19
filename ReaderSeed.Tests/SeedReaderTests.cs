using Microsoft.VisualStudio.TestTools.UnitTesting;
using ReaderSeed;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ReaderSeed.Tests
{
    [TestClass()]
    public class SeedReaderTests
    {
        [TestInitialize]
        public void TestInitialize()
        {
        }

        [TestMethod()]
        public void GetKJVTest()
        {
            var seed = new SeedReader();
            var result = Task.Run(async () => await seed.GetKJV()).Result;

            Assert.IsNotNull(result);
        }
    }
}