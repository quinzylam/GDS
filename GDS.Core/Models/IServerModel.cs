namespace GDS.Core.Models
{
    public interface IServerModel : IModel
    {
        string CreatedBy { get; set; }
        bool IsDeleted { get; set; }
        string ModifiedBy { get; set; }
    }
}