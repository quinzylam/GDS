using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace GDS.KJVAE.Models
{
    [Table("plans")]
    internal class Plan
    {
        [PrimaryKey]
        [Column("_id")]
        public int Id { get; set; }

        [Column("title")]
        public string Title { get; set; }

        [Column("description")]
        public string Description { get; set; }

        [Column("order_val")]
        public int Order { get; set; }

        [Column("start_date")]
        public DateTime StartDate { get; set; }

        [Column("end_date")]
        public DateTime EndDate { get; set; }

        [Column("started")]
        public bool Started { get; set; }

        [Column("mode_ids")]
        public string ModeIds { get; set; }

        [Column("mode_id")]
        public int ModeId { get; set; }

        [Column("notify")]
        public bool Notify { get; set; }

        [Column("notify_time")]
        public DateTime NotifyTime { get; set; }
    }
}