using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BibleReader.Models.Bible
{
    [Table("verses")]
    public class Verse
    {
        [Column("book_number")]
        public int BookNumber { get; set; }

        [Column("chapter")]
        public int Chapter { get; set; }

        [Column("verse")]
        public int VerseNo { get; set; }

        [Column("text")]
        public string Text { get; set; }
    }
}