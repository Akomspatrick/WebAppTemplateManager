using CodeGeneratorAttributesLibrary;

namespace DocumentVersionManager.BaseModels.Entities
{
    public class Document : BaseEntity
    {
        // ProjectBaseModelsAttribute(int maxSize, int minSize, bool isKey, bool isUnique, bool isRequired, bool isForeignKey, string defaultStringValue, bool hasDefaultStringValue)

        [ProjectBaseModelsAttribute(30, 2, true, true, true, false, false, "")]
        public string DocumentName { get; init; } = string.Empty;


        [ProjectBaseModelsAttribute(30, 2, true, true, true, false, false, "")]
        public string ModelName { get; init; } = string.Empty;
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
