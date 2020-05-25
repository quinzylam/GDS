using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GDS.Mobile.Core.Data
{
    public interface IDataStore<T>
    {
        Task<bool> InsertAsync(T item);

        Task<bool> UpdateAsync(T item);

        Task<bool> DeleteAsync(Guid id);

        Task<T> GetAsync(Guid id);

        Task<IEnumerable<T>> GetAsync(bool forceRefresh = false);
    }
}