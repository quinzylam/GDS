using GDS.Core.Models.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GDS.Core.Services
{
    public interface IBibleService<T>
    {
        IEnumerable<T> Get();

        Task<IEnumerable<T>> GetAsync();

        T Get(BibleVersion bible);

        Task<T> GetAsync(BibleVersion bible);
    }
}