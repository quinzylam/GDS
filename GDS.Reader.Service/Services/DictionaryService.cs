using GDS.Reader.Core.Models;
using GDS.Reader.Core.Models.Dictionaries;
using GDS.Reader.Core.Services;
using GDS.Reader.Data;

using System.Linq;

namespace GDS.Reader.Services
{
    public class DictionaryService : IDictionaryService
    {
        private readonly DictionaryContext _ctx;

        public DictionaryService(string name) => _ctx = new DictionaryContext(name);

        public IQueryable<Info> GetInfo() => _ctx.Info.AsQueryable();

        public Info GetInfo(string name) => _ctx.Info.Find(name);

        public IQueryable<Dictionary> GetReferences() => _ctx.Dictionaries.AsQueryable();

        public Dictionary GetReference(string topic) => _ctx.Dictionaries.Find(topic);

        public IQueryable<MorphologyIndication> GetIndications() => _ctx.MorphologyIndications.AsQueryable();

        public MorphologyIndication GetIndication(string indication) => _ctx.MorphologyIndications.Find(indication);
    }
}