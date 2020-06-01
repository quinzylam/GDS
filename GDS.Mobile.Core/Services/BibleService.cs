using GDS.Core.Models;
using GDS.Core.Models.Enums;
using GDS.Core.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GDS.Mobile.Core.Services
{
    public class BibleService : IBibleService<Bible>
    {
        private readonly IRestService _restService;

        public BibleService(IRestService restService)
        {
            _restService = restService;
        }

        public IEnumerable<Bible> Get()
        {
            return Task.Run(async () => await GetAsync()).Result;
        }

        public Bible Get(BibleVersion bible)
        {
            return Task.Run(async () => await GetAsync(bible)).Result;
        }

        public async Task<IEnumerable<Bible>> GetAsync()
        {
            return await _restService.Client.For<Bible>().FindEntriesAsync();
        }

        public async Task<Bible> GetAsync(BibleVersion code)
        {
            return await _restService.Client.For<Bible>().Filter(f => f.Code == code).Expand(x => x.Chapters).FindEntryAsync();
        }
    }
}