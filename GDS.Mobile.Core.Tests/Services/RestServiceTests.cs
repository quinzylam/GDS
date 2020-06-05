using NUnit.Framework;
using GDS.Mobile.Core.Services;
using System;
using System.Collections.Generic;
using System.Text;
using Moq;
using GDS.Core.Logging;
using GDS.Core.Models;
using System.Threading.Tasks;
using System.Linq;

namespace GDS.Mobile.Core.Services.Tests
{
    [TestFixture()]
    public class RestServiceTests
    {
        private RestService _service;
        private Mock<ILogger> _logger;

        [SetUp]
        public void SetUp()
        {
            _logger = new Mock<ILogger>();
            _service = new RestService(_logger.Object);
        }

        [Test()]
        public async Task RestServiceTest()
        {
            var result = await _service.Client.For<Bible>().FindEntriesAsync();
            Assert.IsTrue(result.Any());
        }
    }
}