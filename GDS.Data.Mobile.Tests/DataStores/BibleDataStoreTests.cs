using NUnit.Framework;
using GDS.Data.Mobile.DataStores;
using System;
using System.Collections.Generic;
using System.Text;
using GDS.Core.Data.Mobile;
using GDS.Core.Models;
using System.Threading.Tasks;
using System.Linq;
using GDS.Data.Mobile.Models;

namespace GDS.Data.Mobile.DataStores.Tests
{
    [TestFixture()]
    public class BibleDataStoreTests
    {
        private IMobileContext _ctx;
        private Bible _bible;

        [SetUp]
        public void Setup()
        {
            _ctx = new Context();
            _bible = new Bible { Id = Guid.Parse("088ff243-c402-485f-8a22-3b7e3919c4b1"), Code = Core.Models.Enums.BibleVersion.KJV, NumOfBooks = 66 };
        }

        [Test()]
        public async Task InsertAsyncTest()
        {
            var inserted = await _ctx.Conn.InsertAsync(_bible);
            Assert.IsTrue(inserted > 0);
        }

        [Test()]
        public void BibleDataStoreTest()
        {
            Assert.Fail();
        }

        [Test()]
        public void DeleteAsyncTest()
        {
            Assert.Fail();
        }

        [Test()]
        public async Task GetAsyncTest()
        {
            _bible = await _ctx.Conn.Table<BibleDbo>().FirstOrDefaultAsync();
            Assert.IsNotNull(_bible);
        }

        [Test()]
        public void GetAsyncTest1()
        {
            Assert.Fail();
        }

        [Test()]
        public void UpdateAsyncTest()
        {
            Assert.Fail();
        }
    }
}