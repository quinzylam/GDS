using GDS.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GDS.Wiki.Core.Models
{
    public class Reference:BaseModel
    {
        public string Name { get; set; }
        public string Url { get; set; }
    }
}
