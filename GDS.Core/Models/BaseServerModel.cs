using System;
using System.Collections.Generic;
using System.Text;

namespace GDS.Core.Models
{
    public class BaseServerModel : BaseModel
    {
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
    }
}