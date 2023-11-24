using DocumentVersionManager.DomainBase.Base;
namespace DocumentVersionManager.Domain.Entities
{
    public partial class DocumentDocumentType : BaseEntity
    {
        public string DocumentName { get; init; } = string.Empty;
        public string ModelName { get; init; } = string.Empty;
        public int ModelVersionId { get; init; }
        public string DocumentTypeName { get; init; } = string.Empty;
        public Document Document { get; init; }
        public DocumentType DocumentType { get; init; }
        public Guid GuidId { get; init; }

    }
}