using System;
using System.Collections.Generic;
using System.Text;

namespace GDS.Core.Models
{
    public class Verse : ReadModel
    {
        public Guid? HeadingId { get; set; }
        public Guid BibleBookId { get; set; }
        public int ChapterNum { get; set; }
        public int Position { get; set; }
        public string Text { get; set; }
        public virtual BibleBook BibleBook { get; set; }
    }
}