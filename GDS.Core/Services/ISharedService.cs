using GDS.Core.Models;
using GDS.Core.Models.Enums;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace GDS.Core.Services
{
    public interface ISharedService
    {
        Bible Bible { get; set; }
        Book Book { get; set; }
        BibleBook Chapter { get; set; }
        int ChapterNo { get; set; }
        Verse Verse { get; set; }
        BibleVersion Version { get; }
        BookList BookCode { get; }
        int Position { get; }

        Task<string> GetReferenceAsync(bool includeVersion = false);

        Task<string> GetTitleAsync();

        Task<IEnumerable<Book>> GetCurrentBooks();
    }
}