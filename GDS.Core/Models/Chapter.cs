using GDS.Core.Models.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace GDS.Core.Models
{
    public class BibleBook : ReadModel
    {
        public Guid BookId { get; set; }
        public Guid BibleId { get; set; }
        public BookList? BookCode { get; set; }
        public BibleVersion Version { get; set; }
        public int Num { get; set; }

        public virtual Bible Bible { get; set; }
        public virtual Book Book { get; set; }
        public virtual ICollection<Verse> Verses { get; set; }
    }
}