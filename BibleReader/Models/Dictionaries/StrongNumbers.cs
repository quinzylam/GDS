using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BibleReader.Models.Dictionaries
{
    [Table("cognate_strong_numbers")]
    public class StrongNumbers
    {
        [Column("group_id")]
        public int GroupID { get; set; }

        [Key]
        [Column("strong_number")]
        public string StrongNumber { get; set; }
    }
}