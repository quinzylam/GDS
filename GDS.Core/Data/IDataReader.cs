using GDS.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GDS.Core.Data
{
    public interface IDataReader<T> where T : BaseReaderModel
    {
        Task<IQueryable<T>> GetAsync(bool forceRefresh = false);

        Task<T> GetAsync(int id);
    }
}