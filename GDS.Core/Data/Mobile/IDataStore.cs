using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GDS.Core.Data.Mobile
{
    public interface IDataStore<T>
    {
        Task<bool> InsertAsync(T item);

        Task<bool> UpdateAsync(T item, bool forceRefresh = false);

        Task<bool> DeleteAsync(Guid id);

        Task<T> GetAsync(Guid id);

        Task<IEnumerable<T>> GetAsync();

        bool Any();
    }
}