using GDS.Core.Models.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace GDS.Core.Models
{
    public class Bible : ReadModel
    {
        public BibleVersion Code { get; set; }
        public string Title { get; set; }
        public int NumOfBooks { get; set; }
        public virtual ICollection<Book> Books { get; set; }
    }
}