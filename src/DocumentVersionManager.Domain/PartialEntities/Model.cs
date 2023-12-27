using DocumentVersionManager.DomainBase.Base;
namespace DocumentVersionManager.Domain.Entities
{
    using System.ComponentModel.DataAnnotations;

    public partial class Model  : BaseEntity
    {
        private Model(){}
        public string ModelName    { get; init; }  = string.Empty; 
        public string ModelTypeName    { get; init; }  = string.Empty; 
        public ModelType ModelTypes    { get; init; } 
        private List <ModelVersion> _ModelVersions { get;  set;}  = new List<ModelVersion>();
        public  IReadOnlyCollection<ModelVersion> ModelVersions => _ModelVersions;
        public Guid GuidId    { get; init; } 
        
        public static Model Create(string  modelName, string  modelTypeName, Guid  guidId)
        =>new()
        {
            ModelName = modelName ,
            ModelTypeName = modelTypeName ,
            GuidId = guidId ,
        };
    }
}