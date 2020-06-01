using System;
using System.Linq;
using GDS.Core.Models;
using GDS.Core.Models.Enums;

namespace GDS.Core.Data
{
    public interface IDataStore<T>
    {
        IQueryable<T> Get();

        T Get(Guid id);
    }
}