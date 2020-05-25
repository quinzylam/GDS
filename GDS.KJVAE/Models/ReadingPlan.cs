using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace GDS.KJVAE.Models
{
    [Table("reading_plans")]
    internal class ReadingPlan
    {
        [PrimaryKey]
        [Column("_id")]
        public int Id { get; set; }

        [Column("plan_id")]
        public int PlanId { get; set; }

        [Column("mode_id")]
        public int ModeId { get; set; }

        [Column("day")]
        public int Day { get; set; }

        [Column("chapter_order")]
        public int ChapterOrder { get; set; }

        [Column("viewed")]
        public bool Viewed { get; set; }

        [Column("chapter_num")]
        public int ChapterNum { get; set; }
    }
}