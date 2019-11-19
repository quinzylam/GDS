using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GDS.Core.Models
{
    public class BaseReader : IReaderModel
    {
        [Key]
        public int Id { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}