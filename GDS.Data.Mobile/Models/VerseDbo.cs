using GDS.Core.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace GDS.Data.Mobile.Models
{
    [Table("Verse")]
    public class VerseDbo : Verse
    {
        [PrimaryKey]
        public override Guid Id { get; set; }

        [Ignore]
        public override BibleBook BibleBook { get => base.BibleBook; set => base.BibleBook = value; }
    }
}