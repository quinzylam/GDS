using GDS.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GDS.Bible.Core.Models
{
    public class Chapter : BaseModel
    {
        public int TranslationId { get; set; }
        public int BookId { get; set; }
        public int ChapterNo { get; set; }

        public virtual Translation Translation { get; set; }
        public virtual Book Book { get; set; }
        public virtual ICollection<Verse> Verses { get; set; }

    }
}