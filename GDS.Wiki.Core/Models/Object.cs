using GDS.Core.Models;

namespace GDS.Wiki.Core.Models
{
    public class Object:BaseModel
    {
        public int NameId { get; set; }
        public dynamic Data { get; set; }

        public virtual ObjectName Name { get; set; }
    }
}
