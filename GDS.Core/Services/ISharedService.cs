using GDS.Core.Models;
using GDS.Core.Models.Enums;

namespace GDS.Core.Services
{
    public interface ISharedService
    {
        Bible Bible { get; set; }
        Book Book { get; set; }
        Chapter Chapter { get; set; }
        int ChapterNo { get; set; }
        Verse Verse { get; set; }
        BibleVersion Version { get; }
        BookList BookCode { get; }
        int Position { get; }
    }
}