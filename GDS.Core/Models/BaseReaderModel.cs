using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GDS.Core.Models
{
    public class BaseReaderModel
    {
        [Key]
        public int Id { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}