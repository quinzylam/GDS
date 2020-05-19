using System.Linq;

namespace GDS.Core.Data
{
    public interface IDataStore<T>
    {
        IQueryable<T> Get();
    }
}