using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace GDS.KJVAE.Models
{
    [Table("sqlite_sequence")]
    internal class SqliteSequence
    {
        [Column("name")]
        public string Name { get; set; }

        [Column("seq")]
        public string Sequence { get; set; }
    }
}