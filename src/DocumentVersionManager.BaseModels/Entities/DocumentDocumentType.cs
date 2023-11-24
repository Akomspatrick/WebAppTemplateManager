﻿namespace DocumentVersionManager.BaseModels.Entities
{
    public class DocumentDocumentType : BaseEntity
    {
        public string DocumentName { get; init; } = string.Empty;//documents_name
        public string ModelName { get; init; } = string.Empty;//documents_models_name
        public int ModelVersionId { get; init; }
        public string DocumentTypeName { get; init; } = string.Empty;//documentTypes_name
        public Document Document { get; init; }
        public DocumentType DocumentType { get; init; }

    }
}




