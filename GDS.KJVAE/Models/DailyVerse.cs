using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace GDS.KJVAE.Models
{
    [Table("verses")]
    internal class DailyVerse
    {
        [PrimaryKey]
        [Column("_id")]
        public int Id { get; set; }

        [Column("title")]
        public string Title { get; set; }

        [Column("chapter_ids")]
        public string ChapterIds { get; set; }

        [Column("verse_id")]
        public int VerseId { get; set; }

        [Column("date_of_update")]
        public DateTime DateOfUpdate { get; set; }

        [Column("order_val")]
        public int OrderVal { get; set; }

        [Column("user_create")]
        public int UserCreate { get; set; }

        [Column("notify")]
        public bool Notify { get; set; }

        [Column("notify_time")]
        public DateTime NotifyTime { get; set; }
    }
}