using BibleReader.Models;
using BibleReader.Models.Dictionaries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BibleReader.Services
{
    public class DictionaryService : IDictionaryService
    {
        private readonly DictionaryContext _ctx;

        public DictionaryService(string name)
        {
            _ctx = new DictionaryContext(name);
        }

        public IQueryable<Info> GetInfo()
        {
            return _ctx.Info.AsQueryable();
        }

        public Info GetInfo(string name)
        {
            return _ctx.Info.Find(name);
        }

        public IQueryable<Dictionary> GetReferences()
        {
            return _ctx.Dictionaries.AsQueryable();
        }

        public Dictionary GetReference(string topic)
        {
            return _ctx.Dictionaries.Find(topic);
        }

        public IQueryable<MorphologyIndication> GetIndications()
        {
            return _ctx.MorphologyIndications.AsQueryable();
        }

        public MorphologyIndication GetIndication(string indication)
        {
            return _ctx.MorphologyIndications.Find(indication);
        }
    }
}