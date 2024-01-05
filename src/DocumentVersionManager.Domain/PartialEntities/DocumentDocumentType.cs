using DocumentVersionManager.DomainBase;
namespace DocumentVersionManager.Domain.Entities
{
    using System.ComponentModel.DataAnnotations;

    public partial class DocumentDocumentType : BaseEntity
    {
        private DocumentDocumentType() { }
        public string DocumentName { get; init; } = string.Empty;
        public string ModelName { get; init; } = string.Empty;
        public int ModelVersionId { get; init; }
        public string DocumentTypeName { get; init; } = string.Empty;
        public Document Document { get; init; }
        public DocumentType DocumentType { get; init; }
        public Guid GuidId { get; init; }

        public static DocumentDocumentType Create(string documentName, string modelName, int modelVersionId, string documentTypeName, Guid guidId)
        => new()
        {
            DocumentName = documentName,
            ModelName = modelName,
            ModelVersionId = modelVersionId,
            DocumentTypeName = documentTypeName,
            GuidId = guidId,
        };
    }
}