using System;
using System.Collections.Generic;
using System.Text;

namespace GDS.Core.Services
{
    public interface IBookService<T>
    {
        IEnumerable<T> Get();
    }
}