using GDS.Core.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace GDS.Data.Mobile.Models
{
    [Table("Heading")]
    public class HeadingDbo : Heading
    {
        [PrimaryKey]
        public override Guid Id { get; set; }

        [Ignore]
        public override IEnumerable<Verse> Verses { get => base.Verses; set => base.Verses = value; }
    }
}