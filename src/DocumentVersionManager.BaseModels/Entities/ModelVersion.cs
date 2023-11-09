namespace DocumentVersionManager.BaseModels.Entities
{
    public class ModelVersion:BaseEntity
    {   public int ModelVersionId { get; init; }
        
        public string VersionDescription { get; init; } = string.Empty;
        public string ModelVersionName { get; init; } = string.Empty;


        public Model Models;
        public string ModelName { get; init; } = string.Empty;
       // public Guid ModelVersionGuid { get; init; }
   
        
        public DateTime Timestamp { get; init; }

        public string Username { get; init; } = string.Empty;


        public ICollection<Document> Documents;
        public ICollection<CapacitySpecification> CapacitySpecifications;

      }
}
