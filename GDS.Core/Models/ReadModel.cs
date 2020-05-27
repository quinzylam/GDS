using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GDS.Core.Models
{
    public abstract class ReadModel
    {
        [Key]
        public Guid Id { get; set; }

        public int LocalId { get; set; }
    }
}