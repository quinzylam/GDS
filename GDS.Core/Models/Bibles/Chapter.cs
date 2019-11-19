using System;
using System.Collections.Generic;
using System.Text;

namespace GDS.Core.Models.Bibles
{
    public class Chapter : BaseReader
    {
        public int TranslationId { get; set; }
        public int BookId { get; set; }
        public int Chapters { get; set; }
    }
}