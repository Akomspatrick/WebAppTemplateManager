using CodeGeneratorAttributesLibrary;

namespace DocumentVersionManager.BaseModels.Entities
{
    public class DocumentDocumentType : BaseEntity
    {
        [BaseModelBasicAttribute(32, 0, true, true, true)]
        public string DocumentName { get; init; } = string.Empty;//documents_name
        [BaseModelBasicAttribute(32, 0, true, true, true)]
        public string ModelName { get; init; } = string.Empty;//documents_models_name
        [BaseModelBasicAttribute(true, true)]
        public int ModelVersionId { get; init; }

        [BaseModelBasicAttribute(32, 0, true, true, false)]

        public string DocumentTypeName { get; init; } = string.Empty;//documentTypes_name
        public Document Document { get; init; }
        public DocumentType DocumentType { get; init; }

    }
}




