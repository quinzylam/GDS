using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BibleReader.Models.Commentaries
{
    [Table("comments")]
    public class Comment
    {
        [Key]
        [Column("_id")]
        public int Id { get; set; }

        [Column("chapter_id")]
        public int ChapterId { get; set; }

        [Column("title")]
        public string Title { get; set; }

        [Column("text")]
        public string Text { get; set; }

        [Column("rank")]
        public int Rank { get; set; }
    }
}