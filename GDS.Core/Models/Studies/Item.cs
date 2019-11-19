using System;

namespace GDS.Core.Models.Studies
{
    public class Item : IReaderModel
    {
        public string Text { get; set; }
        public string Description { get; set; }
        public DateTime CreatedOn { get; set; }
        public int Id { get; set; }
    }
}