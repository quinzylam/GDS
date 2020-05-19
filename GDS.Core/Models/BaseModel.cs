using System;
using System.Collections.Generic;
using System.Text;

namespace GDS.Core.Models
{
    public abstract class BaseModel : ReadModel
    {
        public DateTime CreatedOn { get; set; }

        public string CreatedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public string ModifiedBy { get; set; }
    }
}