namespace DocumentVersionManager.BaseModels.Entities
{
    public class HigherModel : BaseEntity<string>
    {
        public string HigherModelName { get; private set; } = string.Empty;
        public string HigherModelDescription { get; private set; } = string.Empty;
        public string ProductId { get; private set; } = string.Empty;
        public int Capacity { get; private set; } = 0;


       }
}
