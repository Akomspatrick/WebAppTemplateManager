using CodeGeneratorAttributesLibrary;

namespace DocumentVersionManager.BaseModels.Entities
{
    public class DocumentType : BaseEntity
    {
        [BaseModelBasicAttribute(32, 0, true, false, true)]
        public string DocumentTypeName { get; init; } = string.Empty;// This is the primary key and the id of the document type name

        public ICollection<DocumentDocumentType> DocumentDocumentTypes { get; set; }


    }
}
