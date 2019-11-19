using System;

namespace GDS.Core.Models
{
    public interface IReaderModel
    {
        DateTime CreatedOn { get; set; }
        int Id { get; set; }
    }
}