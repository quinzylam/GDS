using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace GDS.Bibles.Core.Models
{
    [Table("stories")]
    public class Story
    {
        [Column("book_number")]
        public int BookNo { get; set; }

        [Column("chapter")]
        public int Chapter { get; set; }

        [Column("verse")]
        public int Verse { get; set; }

        [Column("order_if_several")]
        public int Order { get; set; }

        [Column("title")]
        public string Title { get; set; }
    }
}