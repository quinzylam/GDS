using GDS.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GDS.Core.Data
{
    public interface IServerDataStore<T> : IDataReader<T> where T : IServerModel
    {
        Task<IEnumerable<T>> GetAsync(bool forceRefresh = false);

        Task<T> GetAsync(string id);

        Task<bool> UpdateAsync(T model);

        Task<bool> AddAsync(T model);

        Task<bool> DeleteAsync(string id);
    }
}