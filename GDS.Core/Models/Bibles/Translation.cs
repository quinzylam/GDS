using System;
using System.Collections.Generic;
using System.Text;

namespace GDS.Core.Models.Bibles
{
    public class Translation : BaseReader
    {
        public string Title { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public bool HasStrongs { get; set; }

        public ICollection<Book> Books { get; set; }
    }
}