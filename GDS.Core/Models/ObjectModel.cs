using GDS.Core.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace GDS.Core.Models
{
    [Table("Objects")]
    public class ObjectModel : BaseEntity
    {
        public ObjectClass Class { get; set; }
        public bool IsGroup { get; set; }
    }
}