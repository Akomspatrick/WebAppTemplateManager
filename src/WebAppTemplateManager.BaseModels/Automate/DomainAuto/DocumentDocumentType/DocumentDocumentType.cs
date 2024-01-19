using DocumentVersionManager.DomainBase;
namespace DocumentVersionManager.Domain.Entities
{
    public partial class DocumentDocumentType  : BaseEntity
    {
        private DocumentDocumentType(){}
        public string DocumentName    { get; init; }  = string.Empty; 
        public string ModelName    { get; init; }  = string.Empty; 
        public int ModelVersionId    { get; init; } 
        public string DocumentTypeName    { get; init; }  = string.Empty; 
        public Document Document    { get; init; } 
        public DocumentType DocumentType    { get; init; } 
        public Guid GuidId    { get; init; } 
        
        public static DocumentDocumentType Create(string  documentName, string  modelName, int  modelVersionId, string  documentTypeName, Guid  guidId)
    {
    if (guidId == Guid.Empty)
    {
        throw new ArgumentException($"DocumentDocumentType Guid value cannot be empty {nameof(guidId)}");
    }
        return  new()
        {
            DocumentName = documentName ,
            ModelName = modelName ,
            ModelVersionId = modelVersionId ,
            DocumentTypeName = documentTypeName ,
            GuidId = guidId ,
        };
    }
    }
}