using SQLite;

namespace GDS.Bibles.Core.Models
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