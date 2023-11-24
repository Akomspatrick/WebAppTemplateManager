using DocumentVersionManager.DomainBase.Base;
namespace DocumentVersionManager.Domain.Entities
{
    public partial class RevisionCapacityInterval  : BaseEntity
        {
            public int Capacity    { get; init; } 
            public DateTime Timestamp    { get; init; } 
            public string DocumentName    { get; init; }  = string.Empty; 
            public string ModelName    { get; init; }  = string.Empty; 
            public int RevisionNumber    { get; init; } 
        }
}