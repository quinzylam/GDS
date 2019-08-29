using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BibleReader.Models.Bible
{
    [Table("books")]
    public class Book
    {
        [Column("book_color")]
        public string BookColor { get; set; }

        [Key]
        [Column("book_number")]
        public int BookNo { get; set; }

        [Column("short_name")]
        public string ShortName { get; set; }

        [Column("long_name")]
        public string LongName { get; set; }

        public List<Verse> Verses { get; set; }
    }
}