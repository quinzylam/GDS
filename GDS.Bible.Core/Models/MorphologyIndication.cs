using GDS.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GDS.Bible.Core.Models
{
    public class MorphologyIndication:BaseModel
    {
        public string Indication { get; set; }
        public string ApplicableTo { get; set; }
        public string Meaning { get; set; }
    }
}
