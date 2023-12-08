using DocumentVersionManager.DomainBase.Base;
namespace DocumentVersionManager.Domain.Entities
{
    public partial class DocumentType  : BaseEntity
        {
            public string DocumentTypeName    { get; init; }  = string.Empty; 
            private  List <DocumentDocumentType> _DocumentDocumentTypes { get;  set;}  = new List<DocumentDocumentType>();
            public  IReadOnlyCollection<DocumentDocumentType> DocumentDocumentTypes => _DocumentDocumentTypes;
            public Guid GuidId    { get; init; } 
        }
}