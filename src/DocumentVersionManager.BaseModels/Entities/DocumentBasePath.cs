namespace DocumentVersionManager.BaseModels.Entities
{
    public class DocumentBasePath : BaseEntity
    {

        public string DocumentBasePathId { get; init; } = string.Empty;

        public string Path { get; init; } = string.Empty;
        public string Description { get; init; } = string.Empty;


    }
}
