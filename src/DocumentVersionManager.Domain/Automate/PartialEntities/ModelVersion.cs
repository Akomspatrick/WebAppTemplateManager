using DocumentVersionManager.DomainBase.Base;
namespace DocumentVersionManager.Domain.Entities
{
    public partial class ModelVersion  : BaseEntity
        {
            public int ModelVersionId    { get; init; } 
            public string VersionDescription    { get; init; }  = string.Empty; 
            public string ModelVersionName    { get; init; }  = string.Empty; 
            public string ModelName    { get; init; }  = string.Empty; 
            public string TestingModeName    { get; init; }  = string.Empty; 
            public DateTime Timestamp    { get; init; } 
            public string UserName    { get; init; }  = string.Empty; 
            public ICollection<Document> Documents { get; set;}
            public ICollection<CapacitySpecification> CapacitySpecifications { get; set;}
            public Guid GuidId    { get; init; } 
        }
}