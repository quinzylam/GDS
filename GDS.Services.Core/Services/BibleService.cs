using GDS.Core.Data;
using GDS.Core.Models;
using GDS.Core.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace GDS.Services.Core.Services
{
    public class BibleService : IBibleService<Bible>
    {
        private readonly IDataStore<Bible> _dataStore;

        public BibleService(IDataStore<Bible> dataStore)
        {
            _dataStore = dataStore;
        }

        public IEnumerable<Bible> Get()
        {
            return _dataStore.Get();
        }
    }
}