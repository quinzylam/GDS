using GDS.Core.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace GDS.Core.Models
{
    [Table("Times")]
    public class TimeModel : BaseEntity
    {
        public int? Year { get; set; }
        public Months? Month { get; set; }
        public int? Day { get; set; }
        public Enums.DayOfWeek? DOW { get; set; }
    }
}