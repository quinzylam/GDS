using GDS.Core.Data.BaseData;
using GDS.Core.Data.DataStore;
using GDS.Core.Models.Bibles;
using GDS.Core.Models.System;
using GDS.Core.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace GDS.Core.Data.Database
{
    public class MockDataService : IDataService
    {
        private readonly MockDataReader<Translation> _translations;
        private readonly MockDataReader<Book> _books;
        private readonly MockDataReader<Verse> _verse;
        private readonly MockServerDataStore<User> _users;

        public MockDataService()
        {
            _translations = new MockDataReader<Translation>(new List<Translation>());
            _books = new MockDataReader<Book>(new List<Book>());
            _verse = new MockDataReader<Verse>(new List<Verse>());

            _users = new MockServerDataStore<User>(DataSeed.SeedUser());
        }

        public IDataReader<Translation> Translations => _translations;

        public IDataReader<Book> Books => _books;

        public IDataReader<Verse> Verses => _verse;

        public IServerDataStore<User> Users => _users;
    }
}