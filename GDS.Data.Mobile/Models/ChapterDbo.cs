using GDS.Core.Models;
using GDS.Core.Models.Enums;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace GDS.Data.Mobile.Models
{
    [Table("Chapters")]
    public class ChapterDbo
    {
        [PrimaryKey]
        public Guid Id { get; set; }

        public int LocalId { get; set; }
        public BookList BookCode { get; set; }
        public BibleVersion Version { get; set; }
        public int Num { get; set; }
    }
}