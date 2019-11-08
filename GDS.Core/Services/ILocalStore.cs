using GDS.Core.Data;
using GDS.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GDS.Core.Services
{
    public interface ILocalStore<T> : IDataStore<T> where T : BaseModel
    {
    }
}