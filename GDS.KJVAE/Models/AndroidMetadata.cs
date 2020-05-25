using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace GDS.KJVAE.Models
{
    [Table("andoid_metadata")]
    internal class AndroidMetadata
    {
        [Column("locale")]
        public string Locale { get; set; }
    }
}