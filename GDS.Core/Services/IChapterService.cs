using GDS.Core.Models.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GDS.Core.Services
{
    public interface IChapterService<T>
    {
        Task<IEnumerable<T>> GetAsync(BibleVersion bible);

        Task<T> GetAsync(BibleVersion bible, BookList book);
    }
}