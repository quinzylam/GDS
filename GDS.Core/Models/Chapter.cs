using GDS.Core.Models.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace GDS.Core.Models
{
    public class Chapter : ReadModel
    {
        public int LocalId { get; set; }
        public Guid BookId { get; set; }
        public BibleVersion Version { get; set; }
        public int Num { get; set; }

        public virtual Book Book { get; set; }
        public virtual ICollection<Verse> Verses { get; set; }
    }
}