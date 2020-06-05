using GDS.Core.Data.Mobile;
using GDS.Core.Models;
using GDS.Core.Models.Enums;
using GDS.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GDS.Mobile.Core.Services
{
    public class BibleService : IBibleService<Bible>
    {
        private readonly IRestService _restService;
        private readonly IDataStore<Bible> _dataStore;

        public BibleService(IRestService restService)
        {
            _restService = restService;
        }

        public async Task DownloadAsync(BibleVersion code, bool forceRefresh = false)
        {
            if (_dataStore.Any() && !forceRefresh)
                return;
            var bible = await _restService.Client.For<Bible>().Filter(f => f.Code == code).Expand("*").FindEntryAsync();
            await _dataStore.UpdateAsync(bible, true);
        }

        public async Task<IEnumerable<Bible>> GetAsync()
        {
            var result = await _dataStore.GetAsync();
            if (result.Any())
                return result;
            else if (_restService.IsOnline)
                return await _restService.Client.For<Bible>().FindEntriesAsync();
            return null;
        }

        public async Task<Bible> GetAsync(BibleVersion code)
        {
            return await _restService.Client.For<Bible>().Filter(f => f.Code == code).Expand(x => x.BibleBooks).FindEntryAsync();
        }
    }
}