using DocumentVersionManager.DomainBase.Base;
namespace DocumentVersionManager.Domain.Entities
{
    public partial class ModelVersion : BaseEntity
    {
        public int ModelVersionId { get; init; }

        public string VersionDescription { get; init; } = string.Empty;
        public string ModelVersionName { get; init; } = string.Empty;


        public Model Models;
        public string ModelName { get; init; } = string.Empty;

        public string DefaultTestingMode { get; init; } = string.Empty; // Manual, Automatic for each product


        public DateTime Timestamp { get; init; }

        public string UserName { get; init; } = string.Empty;


        public ICollection<Document> Documents { get; init; }
        public ICollection<Specification> CapacitySpecifications { get; init; }
        public ICollection<Product> Products { get; set; }
    }
}