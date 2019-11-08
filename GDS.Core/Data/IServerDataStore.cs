using GDS.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GDS.Core.Data
{
    public interface IServerDataStore<T> : IDataStore<T> where T : BaseServerModel
    {
        Task<T> GetAsync(string id);

        Task<bool> DeleteAsync(string id);
    }
}