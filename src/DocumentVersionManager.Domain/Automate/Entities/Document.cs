namespace DocumentVersionManager.Domain.BaseModels.Entities
{
    public  class Document  : BaseEntity
        {
            public string DocumentName    { get; init; }  = string.Empty; 
            public string ModelName    { get; init; }  = string.Empty; 
            public int ModelVersionId    { get; init; } 
            public string ContentPDFPath    { get; init; }  = string.Empty; 
            public string ChangeOrderPDFPath    { get; init; }  = string.Empty; 
            public string DocumentDescription    { get; init; }  = string.Empty; 
            public DateTime Timestamp    { get; init; } 
            public ICollection<DocumentDocumentType> DocumentDocumentTypes { get; set;}
            public Guid GuidId    { get; init; } 
        }
}