using System.Linq;
using GDS.Reader.Core.Models;
using GDS.Reader.Core.Models.Dictionaries;

namespace GDS.Reader.Core.Services
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