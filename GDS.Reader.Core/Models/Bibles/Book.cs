using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace GDS.Reader.Core.Models.Bibles
{
    [Table("books")]
    [DataContract]
    public class Book
    {
        [Column("book_color")]
        [DataMember]
        public string BookColor { get; set; }

        [Key]
        [Column("book_number")]
        [DataMember]
        public int BookNumber { get; set; }

        [Column("short_name")]
        [DataMember]
        public string ShortName { get; set; }

        [Column("long_name")]
        [DataMember]
        public string LongName { get; set; }
    }
}