using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace GDS.Bibles.Core.Models
{
    [Table("books_all")]
    public class BookHeader
    {
        [PrimaryKey]
        [Column("book_number")]
        public int BookNo { get; set; }

        [Column("short_name")]
        public string ShortName { get; set; }

        [Column("long_name")]
        public string LongName { get; set; }

        [Column("book_color")]
        public string BookColor { get; set; }

        [Column("is_present")]
        public bool IsPresent { get; set; }

        [Column("sorting_order")]
        public int SortOrder { get; set; }
    }
}