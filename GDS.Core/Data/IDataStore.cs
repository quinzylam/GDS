using GDS.Core.Models;
using GDS.Core.Models.Studies;
using GDS.Core.Models.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GDS.Core.Data
{
    public interface IDataStore<T> : IDataReader<T> where T : BaseModel
    {
        Task<bool> CreateAsync(T model);

        Task<bool> DeleteAsync(int id);

        Task<bool> UpdateAsync(T model);
    }
}