using GDS.Core.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace GDS.Data.Mobile.Models
{
    [Table("Book")]
    public class BookDbo : Book
    {
        [PrimaryKey]
        public override Guid Id { get; set; }

        [Ignore]
        public override IEnumerable<BibleBook> BibleBooks { get; set; }
    }
}