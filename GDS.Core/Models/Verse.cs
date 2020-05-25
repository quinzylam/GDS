using System;
using System.Collections.Generic;
using System.Text;

namespace GDS.Core.Models
{
    public class Verse : ReadModel
    {
        public Guid ChapterId { get; set; }
        public int ChapterNum { get; set; }
        public int Position { get; set; }
        public string Text { get; set; }
    }
}