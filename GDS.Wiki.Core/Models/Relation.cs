using GDS.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GDS.Wiki.Core.Models
{
    public class Relation:BaseModel
    {
        public int NameId { get; set; }
        public int LeftId { get; set; }
        public int RightId { get; set; }
        public dynamic Properties { get; set; }

        public virtual RelationName Name { get; set; }
        public virtual Object LeftObject { get; set; }
        public virtual Object RightObject { get; set; }
    }
}
