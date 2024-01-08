using DocumentVersionManager.DomainBase;
namespace DocumentVersionManager.Domain.Entities
{
    using System.ComponentModel.DataAnnotations;

    public partial class ModelTypeGroup  : BaseEntity
    {
        private ModelTypeGroup(){}
        public string ModelTypeGroupName    { get; init; }  = string.Empty; 
        public string TestingMode    { get; init; }  = string.Empty; 
        public string Description    { get; init; }  = string.Empty; 
        private  List <ModelType> _ModelTypes { get;  set;}  = new List<ModelType>();
        public  IReadOnlyCollection<ModelType> ModelTypes => _ModelTypes;
        public Guid GuidId    { get; init; } 
        
        public static ModelTypeGroup Create(string  modelTypeGroupName, string  testingMode, string  description, Guid  guidId)
    {
    if (guidId == Guid.Empty)
    {
        throw new ArgumentException($"ModelTypeGroup Guid value cannot be empty {nameof(guidId)}");
    }
        return  new()
        {
            ModelTypeGroupName = modelTypeGroupName ,
            TestingMode = testingMode ,
            Description = description ,
            GuidId = guidId ,
        };
    }
    }
}