using DocumentVersionManager.DomainBase.Base;
namespace DocumentVersionManager.Domain.Entities
{
    public partial class DocumentBasePath  : BaseEntity
        {
            public string DocumentBasePathId    { get; init; }  = string.Empty; 
            public string Path    { get; init; }  = string.Empty; 
            public string Description    { get; init; }  = string.Empty; 
            public Guid GuidId    { get; init; } 
        }
}