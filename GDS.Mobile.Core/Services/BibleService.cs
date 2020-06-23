using GDS.Core.Data.Mobile;
using GDS.Core.Models;
using GDS.Core.Models.Enums;
using GDS.Core.Services;
using Microsoft.OData.Edm;
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

        public BibleService(IRestService restService, IDataStore<Bible> dataStore)
        {
            _restService = restService;
            _dataStore = dataStore;
        }

        public async Task<IEnumerable<Bible>> GetAsync(bool forceUpdate)
        {
            var result = await _dataStore.GetAsync();
            if (result.Any() && !forceUpdate)
                return result;
            else if (_restService.IsOnline)
            {
                result = await _restService.Client.For<Bible>().FindEntriesAsync();
                foreach (var item in result)
                    await _dataStore.UpdateAsync(item, forceUpdate);
            }
            return result;
        }

        public async Task<Bible> GetAsync(BibleVersion code)
        {
            return await _restService.Client.For<Bible>().Filter(f => f.Code == code).Expand(x => x.BibleBooks).FindEntryAsync();
        }
    }
}