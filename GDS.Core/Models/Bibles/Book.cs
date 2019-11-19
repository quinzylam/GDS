using GDS.Core.Models.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace GDS.Core.Models.Bibles
{
    public class Book : BaseReader
    {
        public string Title { get; set; }

        public string ShortTitle { get; set; }

        public Section Section { get; set; }
        public string Colour { get; set; }
        public ICollection<Verse> Verses { get; set; }
    }
}