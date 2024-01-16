using CodeGeneratorAttributesLibrary;

namespace DocumentVersionManager.BaseModels.Entities
{
    [BaseModelsForeignKeyAttribute("ModelVersion", "Documents")]
    public class Document : BaseEntity
    {
        [BaseModelBasicAttribute(32, 0, true, false)]
        public string DocumentName { get; init; } = string.Empty;


        [BaseModelBasicAttribute(32, 0, true, true)]
        public string ModelName { get; init; } = string.Empty;
        [BaseModelBasicAttribute(true, true)]
        public int ModelVersionId { get; init; }
        //public Guid DocumentGuid { get; init; }
        public string ContentPDFPath { get; init; } = string.Empty;
        public string ChangeOrderPDFPath { get; init; } = string.Empty;
        public string DocumentBasePathId { get; init; } = string.Empty;

        public string DocumentDescription { get; init; } = string.Empty;
        public DateTime Timestamp { get; init; }


        public ModelVersion ModelVersion { get; init; }

        public ICollection<DocumentDocumentType> DocumentDocumentTypes { get; set; }


    }
}
