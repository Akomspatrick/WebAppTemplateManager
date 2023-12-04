using DocumentVersionManager.DomainBase.Base;
namespace DocumentVersionManager.Domain.Entities
{
    public partial class DocumentType  : BaseEntity
        {
            public string DocumentTypeName    { get; init; }  = string.Empty; 
            private  IList <DocumentDocumentType> _DocumentDocumentTypes { get;  set;}  = new List<DocumentDocumentType>();
            public  IEnumerable<DocumentDocumentType> DocumentDocumentTypes => _DocumentDocumentTypes.AsReadOnly();
            public Guid GuidId    { get; init; } 
        }
}