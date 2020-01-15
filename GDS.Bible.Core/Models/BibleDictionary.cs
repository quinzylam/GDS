using GDS.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GDS.Bible.Core.Models
{
    public class BibleDictionary:BaseModel
    {
        public string Topic { get; set; }
        public string Definition { get; set; }
        public string Lexeme { get; set; }
        public string Transliteration { get; set; }
        public string Pronunciation { get; set; }
        public string ShortDefinition { get; set; }

        public virtual CognateStrongNumber CognateStrongNumber { get; set; }
    }
}
