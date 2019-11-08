using System;
using System.Collections.Generic;
using System.Text;

namespace GDS.Core.Models
{
    public class BaseModel : BaseReaderModel
    {
        public string Gid { get; set; }
        public string Username { get; set; }
        public DateTime? SyncedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
    }
}