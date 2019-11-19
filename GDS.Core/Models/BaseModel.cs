using GDS.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GDS.Core.Models
{
    public class BaseModel : BaseReader, IModel
    {
        public string Gid { get; set; }
        public string Name { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public DateTime? SyncedOn { get; set; }
        public string Username { get; set; }
    }
}