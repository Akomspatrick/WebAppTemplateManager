namespace DocumentVersionManager.Domain.BaseModels.Entities
{
    public  class DocumentType  : BaseEntity
        {
            public string TypeName    { get; init; }  = string.Empty; 
            public ICollection<DocumentDocumentType> DocumentDocumentTypes { get; set;}
            public Guid GuidId    { get; init; } 
        }
}