using Autofac.Extras.Moq;
using GDS.Core.Services;
using GDS.MockFactory.Data.Database;
using System;
using System.Collections.Generic;
using System.Text;

namespace GDS.MockFactory
{
    public static class SUT
    {
        public static AutoMock Mock;

        public static void Setup()
        {
            Mock = AutoMock.GetStrict();
            Mock.Provide<IDataService>(new MockDataService());
        }
    }
}