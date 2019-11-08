using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GDS.Data.Mobile.Models
{
    public class Bible
    {
        [Key]
        public int Id { get; set; }
        public string ShortCode { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool UseStrongs { get; set; }
    }
}
