using GDS.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GDS.Bible.Core.Models
{
    public class Verse : BaseModel
    {
        public int ChapterId { get; set; }
        public int VerseNo { get; set; }
        public string Text { get; set; }

        public virtual Chapter Chapter { get; set; }
    }
}