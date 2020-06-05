using GDS.Core.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace GDS.Data.Mobile.Models
{
    [Table("BibleBook")]
    public class BibleBookDbo : BibleBook
    {
        [PrimaryKey]
        public override Guid Id { get; set; }

        [Ignore]
        public override Bible Bible { get => base.Bible; set => base.Bible = value; }

        [Ignore]
        public override Book Book { get => base.Book; set => base.Book = value; }

        [Ignore]
        public override ICollection<Verse> Verses { get => base.Verses; set => base.Verses = value; }
    }
}