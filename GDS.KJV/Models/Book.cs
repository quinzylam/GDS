using System.Collections.Generic;
using System.Runtime.Serialization;
using SQLite;

namespace GDS.KJV.Models
{
    [Table("books")]
    public class Book
    {
        [Column("book_color")]
        public string BookColor { get; set; }

        [PrimaryKey]
        [Column("book_number")]
        public int BookNumber { get; set; }

        [Column("short_name")]
        public string ShortName { get; set; }

        [Column("long_name")]
        public string LongName { get; set; }
    }
}