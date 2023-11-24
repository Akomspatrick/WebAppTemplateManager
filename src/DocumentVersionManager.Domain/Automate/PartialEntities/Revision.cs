using DocumentVersionManager.DomainBase.Base;
namespace DocumentVersionManager.Domain.Entities
{
    public partial class Revision  : BaseEntity
        {
            public DateTime Timestamp    { get; init; } 
            public string DocumentName    { get; init; }  = string.Empty; 
            public string ModelName    { get; init; }  = string.Empty; 
            public int RevisionNumber    { get; init; } 
            public string DocumentContentPath    { get; init; }  = string.Empty; 
            public string ChangeOrderDocumentPath    { get; init; }  = string.Empty; 
            public string UserName    { get; init; }  = string.Empty; 
        }
}