using DocumentVersionManager.DomainBase.Base;
namespace DocumentVersionManager.Domain.Entities
{
    public partial class DocumentType  : BaseEntity
        {
            public string DocumentTypeName    { get; init; }  = string.Empty; 
            public ICollection<DocumentDocumentType> DocumentDocumentTypes { get; set;}
            public Guid GuidId    { get; init; } 
        }
}