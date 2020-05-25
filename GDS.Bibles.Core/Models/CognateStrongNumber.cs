using GDS.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GDS.Bible.Core.Models
{
    public class CognateStrongNumber:BaseModel
    {
        public int GroupId { get; set; }
        public string StrongNumber { get; set; }
    }
}
