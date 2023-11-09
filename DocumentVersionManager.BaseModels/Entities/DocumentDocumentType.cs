namespace DocumentVersionManager.BaseModels.Entities
{
    public class DocumentDocumentType
    {
        public string DocumentName { get; init; } = string.Empty;//documents_name
        public string ModelName { get; init; } = string.Empty;//documents_models_name
        public int ModelVersionId { get; init; }
        public string DocumentTypeName { get; init; } = string.Empty;//documentTypes_name
        public Document Document;
        public DocumentType DocumentType;

    }
}




