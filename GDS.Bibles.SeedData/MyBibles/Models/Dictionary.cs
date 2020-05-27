using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace GDS.Bible.SeedData.MyBibles.Models
{
    [Table("dictionary")]
    public class Dictionary
    {
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
