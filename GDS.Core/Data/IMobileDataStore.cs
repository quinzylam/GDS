using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GDS.Core.Data
{
    public interface IMobileDataStore<T>
    {
        void Delete(object id);

        IQueryable<T> Get();

        T Get(object id);

        void Insert(T model);

        bool Save(T model);

        void Update(T model);
    }
}