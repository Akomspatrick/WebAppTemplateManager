using DocumentVersionManager.DomainBase.Base;
namespace DocumentVersionManager.Domain.Entities
{
    using System.ComponentModel.DataAnnotations;

    public partial class ModelType  : BaseEntity
    {
        private ModelType(){}
            public string ModelTypeName    { get; init; }  = string.Empty; 
        private  List <Model> _Models { get;  set;}  = new List<Model>();
        public  IReadOnlyCollection<Model> Models => _Models;
            public Guid GuidId    { get; init; } 
        
        public static ModelType Create(string  modelTypeName, Guid  guidId)
        =>new()
        {
            ModelTypeName = modelTypeName ,
            GuidId = guidId ,
        };
    }
}