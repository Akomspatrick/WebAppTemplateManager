using CodeGeneratorAttributesLibrary;

namespace DocumentVersionManager.BaseModels.Entities
{
    public class ModelTypeGroup : BaseEntity
    {
        [BaseModelBasicAttribute(32, 0, true, false, true)]
        public string ModelTypeGroupName { get; init; }
        //(int maxSize, int minSize, bool isKey, bool isUnique, bool isRequired, bool isForeignKey, bool hasDefaultStringValue, string defaultStringValue)
        [BaseModelBasicAttribute(32, 0, false, false, false)]
        public string TestingMode { get; init; } = string.Empty;

        [BaseModelBasicAttribute(64, 0, false, false, false)]
        public string Description { get; init; } = string.Empty;

        public ICollection<ModelType> ModelTypes { get; set; }


    }
}
