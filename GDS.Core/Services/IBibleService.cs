using GDS.Core.Models.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GDS.Core.Services
{
    public interface IBibleService<T>
    {
        Task<IEnumerable<T>> GetAsync(bool forceUpdate);

        Task<T> GetAsync(BibleVersion bible);
    }
}