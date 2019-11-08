using SQLite;

namespace GDS.Data.Mobile.Reader.Models.Bibles
{
    [Table("verses")]
    public class VerseDto
    {
        public VerseDto()
        {
        }

        [PrimaryKey]
        [Column("book_number")]
        public int BookNumber { get; set; }

        [PrimaryKey]
        [Column("chapter")]
        public int Chapter { get; set; }

        [PrimaryKey]
        [Column("verse")]
        public int VerseNo { get; set; }

        [Column("text")]
        public string Text { get; set; }
    }
}