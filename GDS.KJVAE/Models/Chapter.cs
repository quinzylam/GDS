using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace GDS.KJVAE.Models
{
    [Table("chapters")]
    public class Chapter
    {
        [PrimaryKey]
        [Column("_id")]
        public int Id { get; set; }

        [Column("title")]
        public string Title { get; set; }

        [Column("num")]
        public int NumOfChapters { get; set; }

        [Column("mode")]
        public int Mode { get; set; }

        [Column("short_title")]
        public string ShortTitle { get; set; }

        [Column("ntitle")]
        public string NTitle { get; set; }
    }
}