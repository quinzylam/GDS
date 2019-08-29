using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BibleReader.Models.Commentaries
{
    [Table("cchapters")]
    public class Chapter
    {
        [Key]
        [Column("_id")]
        public int Id { get; set; }

        [Column("parent_id")]
        public int ParentId { get; set; }

        [Column("title")]
        public string Title { get; set; }

        [Column("short_title")]
        public string ShortTitle { get; set; }

        [Column("mode")]
        public int Mode { get; set; }

        [Column("rank")]
        public int Rank { get; set; }
    }
}