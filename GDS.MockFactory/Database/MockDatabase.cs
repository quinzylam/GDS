using GDS.Core.Data;
using GDS.Core.Data.BaseData;
using GDS.Core.Models.Administration;
using GDS.Core.Models.Bibles;
using GDS.Core.Services;
using GDS.MockFactory.Data.DataStore;

namespace GDS.MockFactory.Data.Database
{
    public class MockDataService : IDataService
    {
        public MockDataService()
        {
            Users = new MockDataStore<User>(DataSeed.SeedUser());
        }

        public IDataStore<User> Users { get; }

        public IDataReader<Translation> Translations => throw new System.NotImplementedException();

        public IDataReader<Book> Books => throw new System.NotImplementedException();

        public IDataReader<Verse> Verses => throw new System.NotImplementedException();
    }
}