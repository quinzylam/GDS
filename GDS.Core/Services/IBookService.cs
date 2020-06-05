using GDS.Core.Models;
using GDS.Core.Models.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GDS.Core.Services
{
    public interface IBookService<T>
    {
        Task<IEnumerable<T>> GetAsync();

        Task<T> GetAsync(BookList code);

        Task<IEnumerable<Book>> GetBooksForVersionAsync(BibleVersion version);
    }
}