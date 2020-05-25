using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace GDS.KJVAE.Models
{
    internal class Version
    {
        [Column("code")]
        public int Code { get; set; }
    }
}