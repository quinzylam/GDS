using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GDS.Reader.Core.Models.Dictionaries
{
    [Table("dictionary")]
    public class Dictionary
    {
        [Key]
        [Column("topic")]
        public string Topic { get; set; }

        [Column("definition")]
        public string Definition { get; set; }

        [Column("lexeme")]
        public string Lexeme { get; set; }

        [Column("transliteration")]
        public string Transliteration { get; set; }

        [Column("pronunciation")]
        public string Pronunciation { get; set; }

        [Column("short_definition")]
        public string ShortDefinition { get; set; }
    }
}