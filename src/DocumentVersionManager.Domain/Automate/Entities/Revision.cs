namespace DocumentVersionManager.Domain.BaseModels.Entities
{
    public  class Revision  : BaseEntity
        {
            public DateTime Timestamp    { get; init; } 
            public string DocumentName    { get; init; }  = string.Empty; 
            public string ModelName    { get; init; }  = string.Empty; 
            public int RevisionNumber    { get; init; } 
            public string DocumentContentPath    { get; init; }  = string.Empty; 
            public string ChangeOrderDocumentPath    { get; init; }  = string.Empty; 
            public string Username    { get; init; }  = string.Empty; 
        }
}