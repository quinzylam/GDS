using System.Linq;
using BibleReader.Models;
using BibleReader.Models.Dictionaries;

namespace BibleReader.Services
{
    public interface IDictionaryService
    {
        MorphologyIndication GetIndication(string indication);
        IQueryable<MorphologyIndication> GetIndications();
        IQueryable<Info> GetInfo();
        Info GetInfo(string name);
        Dictionary GetReference(string topic);
        IQueryable<Dictionary> GetReferences();
    }
}