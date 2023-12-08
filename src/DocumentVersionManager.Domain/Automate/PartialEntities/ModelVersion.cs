using DocumentVersionManager.DomainBase.Base;
namespace DocumentVersionManager.Domain.Entities
{
    public partial class ModelVersion  : BaseEntity
        {
            public int ModelVersionId    { get; init; } 
            public string VersionDescription    { get; init; }  = string.Empty; 
            public string ModelVersionName    { get; init; }  = string.Empty; 
            public Model Models    { get; init; } 
            public string ModelName    { get; init; }  = string.Empty; 
            public string TestingModeName    { get; init; }  = string.Empty; 
            public DateTime Timestamp    { get; init; } 
            public string UserName    { get; init; }  = string.Empty; 
            private  List <Document> _Documents { get;  set;}  = new List<Document>();
            public  IReadOnlyCollection<Document> Documents => _Documents;
            public Specification Specification    { get; init; } 
            private  List <Product> _Products { get;  set;}  = new List<Product>();
            public  IReadOnlyCollection<Product> Products => _Products;
            public Guid GuidId    { get; init; } 
        }
}