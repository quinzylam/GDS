using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GDS.Mobile.Services
{
    public interface IDataStore<T>
    {
        Task<bool> InsertAsync(T item);

        Task<bool> UpdateAsync(T item);

        Task<bool> DeleteAsync(string id);

        Task<T> GetAsync(string id);

        Task<IEnumerable<T>> GetAsync(bool forceRefresh = false);
    }
}