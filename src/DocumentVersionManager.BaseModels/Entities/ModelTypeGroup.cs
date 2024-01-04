namespace DocumentVersionManager.BaseModels.Entities
{
    public class ModelTypeGroup : BaseEntity
    {
        public string ModelTypeGroupName { get; init; }

        public string TestingMode { get; init; } = string.Empty;
        public string Description { get; init; } = string.Empty;

        public ICollection<ModelType> ModelTypes { get; set; }


    }
}
