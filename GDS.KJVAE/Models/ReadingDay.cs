using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace GDS.KJVAE.Models
{
    [Table("reading_days")]
    internal class ReadingDay
    {
        [PrimaryKey]
        [Column("_id")]
        public int Id { get; set; }

        [Column("plan_id")]
        public int PlanId { get; set; }

        [Column("day")]
        public int Day { get; set; }

        [Column("readed")]
        public bool Readed { get; set; }
    }
}