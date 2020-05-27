using GDS.Core.Models.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace GDS.Core.Models
{
    public class Book : ReadModel
    {
        public BookList Code { get; set; }
        public string Title { get; set; }
        public string ShortTitle { get; set; }
        public Section Section { get; set; }
        public string NTitle { get; set; }

        public virtual IEnumerable<Chapter> Chapters { get; set; }
    }
}