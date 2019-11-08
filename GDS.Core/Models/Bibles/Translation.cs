using System;
using System.Collections.Generic;
using System.Text;

namespace GDS.Core.Models.Bibles
{
    public class Translation : BaseReaderModel
    {
        public string Title { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public bool HasStrongs { get; set; }
        public IEnumerable<Book> Books { get; set; }
    }
}