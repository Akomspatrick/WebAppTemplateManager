using CodeGeneratorAttributesLibrary;

namespace DocumentVersionManager.BaseModels.Entities
{
    public class DocumentBasePath : BaseEntity
    {
        [BaseModelBasicAttribute(128, 0, true, false)]
        public string DocumentBasePathId { get; init; } = string.Empty;
        [BaseModelBasicAttribute(128, 0, false, false)]
        public string Path { get; init; } = string.Empty;
        [BaseModelBasicAttribute(128, 0, false, false)]
        public string Description { get; init; } = string.Empty;


    }
}
