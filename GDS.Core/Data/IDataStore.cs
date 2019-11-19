using GDS.Core.Models;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GDS.Core.Data
{
    public interface IDataStore<T> : IDataReader<T> where T : IModel
    {
        Task<T> GetAsync(int id);

        Task<IEnumerable<T>> GetAsync();

        Task<bool> AddAsync(T model);

        Task<bool> DeleteAsync(int id);

        Task<bool> UpdateAsync(T model);

        Task<int> SaveAsync(T model);
    }
}