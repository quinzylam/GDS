using GDS.Core.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace GDS.Core.Models
{
    [Table("Actions")]
    public class ActionModel : BaseEntity
    {
        public ActionType Type { get; set; }
    }
}