using GDS.Reader.Core.Models.Bibles;
using GDS.Reader.Core.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GDS.UI.Models
{
    public class BookModel
    {
        [Key]
        public int BookNumber { get; set; }

        public Translations Translation { get; set; }

        public string ShortName { get; set; }

        public string LongName { get; set; }

        public IEnumerable<Verse> Verses { get; set; }
    }
}