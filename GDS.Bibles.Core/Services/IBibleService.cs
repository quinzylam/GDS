using GDS.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GDS.Bibles.Core.Services
{
    public interface IBibleService
    {
        IEnumerable<BibleBook> BibleBooks { get; set; }
        IEnumerable<Verse> Verses { get; set; }
        IEnumerable<Book> Books { get; }
        IEnumerable<Heading> Headings { get; set; }
        Bible Bible { get; }
    }
}