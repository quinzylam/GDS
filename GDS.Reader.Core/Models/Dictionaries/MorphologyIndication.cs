using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GDS.Reader.Core.Models.Dictionaries
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