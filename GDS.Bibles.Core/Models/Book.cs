using GDS.Bible.Core.Models.Enums;
using GDS.Core.Models;

namespace GDS.Bible.Core.Models
{
    public class Book:BaseModel
    {
        public int BookNo { get; set; }
        public string Title { get; set; }
        public string ShortTitle { get; set; }
        public Section Section { get; set; }
        public string Colour { get; set; }
        
    }
}