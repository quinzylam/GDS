using System;
using System.Collections.Generic;
using System.Text;

namespace GDS.Core.Models
{
    public class BaseServer : BaseModel, IServerModel
    {
        public string CreatedBy { get; set; }
        public bool IsDeleted { get; set; }
        public string ModifiedBy { get; set; }
    }
}