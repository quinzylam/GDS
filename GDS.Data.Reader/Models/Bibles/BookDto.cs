using SQLite;
using System.Collections.Generic;

namespace GDS.Data.Mobile.Reader.Models.Bibles
{
    [Table("books")]
    public class BookDto
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

        [Ignore]
        public IEnumerable<VerseDto> Verses { get; set; }
    }
}