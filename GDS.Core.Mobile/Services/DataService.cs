using GDS.Core.Data;
using GDS.Core.Models.Bibles;
using GDS.Core.Models.System;
using GDS.Core.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace GDS.Core.Mobile.Services
{
    public class DataService : IDataService
    {
        public DataService()
        {
        }

        public IDataReader<Translation> Translations => throw new NotImplementedException();

        public IDataReader<Book> Books => throw new NotImplementedException();

        public IDataReader<Verse> Verses => throw new NotImplementedException();

        public IServerDataStore<User> Users => throw new NotImplementedException();
    }
}