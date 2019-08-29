using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BibleReader.Models.Dictionaries
{
    [Table("morphology_indications")]
    public class MorphologyIndication
    {
        [Key]
        [Column("indication")]
        public string Indication { get; set; }

        [Column("applicable_to")]
        public string ApplicableTo { get; set; }

        [Column("meaning")]
        public string Meaning { get; set; }
    }
}