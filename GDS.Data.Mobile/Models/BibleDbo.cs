using GDS.Core.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace GDS.Data.Mobile.Models
{
    [Table("Bible")]
    public class BibleDbo : Bible
    {
        [PrimaryKey]
        public override Guid Id { get; set; }

        [Ignore]
        public override ICollection<BibleBook> BibleBooks { get; set; }
    }
}