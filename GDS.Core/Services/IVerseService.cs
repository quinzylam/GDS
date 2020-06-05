using GDS.Core.Models.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GDS.Core.Services
{
    public interface IVerseService<T>
    {
        Task<IEnumerable<T>> GetAsync(BibleVersion bible, BookList book, int chapter);
    }
}