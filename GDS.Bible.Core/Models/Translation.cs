using GDS.Bible.Core.Models.Enums;
using GDS.Core.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GDS.Bible.Core.Models
{
    public class Translation : BaseModel
    {
        public string Title { get; set; }
        public BibleVersion Code { get; set; }
        public string Description { get; set; }
        [Display(Name = "Use Strongs")]
        public bool HasStrongs { get; set; }
        public virtual ICollection<Chapter> Chapters { get; set; }
       
    }
}