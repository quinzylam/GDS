using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace GDS.KJV.Models
{
    [Table("morphology_indications")]
    public class MorphologyIndication
    {
        [Column("indication")]
        public string Indication { get; set; }

        [Column("applicable_to")]
        public string ApplicableTo { get; set; }

        [Column("meaning")]
        public string Meaning { get; set; }
    }
}