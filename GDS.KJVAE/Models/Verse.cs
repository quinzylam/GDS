using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace GDS.KJVAE.Models
{
    [Table("texts")]
    public class Verse
    {
        [PrimaryKey]
        [Column("_id")]
        public int Id { get; set; }

        [Column("chapter_id")]
        public int ChapterId { get; set; }

        [Column("chapter_num")]
        public int ChapterNum { get; set; }

        [Column("position")]
        public int Position { get; set; }

        [Column("text")]
        public string Text { get; set; }

        [Column("rank")]
        public int? Rank { get; set; }

        [Column("bookmark")]
        public int? Bookmark { get; set; }

        [Column("highlight")]
        public int? Highlight { get; set; }

        [Column("note")]
        public string Note { get; set; }

        [Column("bookmark_date")]
        public DateTime? BookmarkDate { get; set; }

        [Column("highlight_date")]
        public DateTime? HighlightDate { get; set; }

        [Column("note_date")]
        public DateTime? NoteDate { get; set; }

        [Column("ntext")]
        public string NText { get; set; }
    }
}