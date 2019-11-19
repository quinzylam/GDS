using System;

namespace GDS.Core.Models
{
    public interface IModel : IReaderModel
    {
        string Gid { get; set; }
        DateTime? ModifiedOn { get; set; }
        DateTime? SyncedOn { get; set; }
        string Username { get; set; }
    }
}