using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace GDS.Bible.SeedData.MyBibles.Models
{
    [Table("cognate_strong_numbers")]
    public class CognateStrongNumber
    {
        [Column("group_id")]
        public int GroupId { get; set; }
        [Column("strong_number")]
        public string StrongNumber { get; set; }
    }
}
