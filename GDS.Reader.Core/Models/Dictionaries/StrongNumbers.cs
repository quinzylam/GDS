using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GDS.Reader.Core.Models.Dictionaries
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