using GDS.Bible.Core.Models;
using GDS.Core.Data;
using System.Collections.Generic;

namespace GDS.Services.Core.Services
{
    public class TranslationService
    {
        private readonly IDataStore<Translation> _dataStore;

        public TranslationService(IDataStore<Translation> dataStore)
        {
            _dataStore = dataStore;
        }

        public IEnumerable<Translation> Get()
        {
            return _dataStore.Get();
        }
    }
}
