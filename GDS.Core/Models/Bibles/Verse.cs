using System;
using System.Collections.Generic;
using System.Text;

namespace GDS.Core.Models.Bibles
{
    public class Verse : BaseReader
    {
        public int BookId { get; set; }

        public int Chapter { get; set; }

        public int VerseNo { get; set; }

        public string Text { get; set; }
    }
}