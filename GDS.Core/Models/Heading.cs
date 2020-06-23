using GDS.Core.Models.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace GDS.Core.Models
{
    public class Heading : ReadModel
    {
        public Guid BookId { get; set; }
        public int Chapter { get; set; }
        public int Position { get; set; }
        public int Order { get; set; }
        public string Title { get; set; }
        public virtual IEnumerable<Verse> Verses { get; set; }
    }
}