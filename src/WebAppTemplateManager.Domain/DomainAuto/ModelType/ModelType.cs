using WebAppTemplateManager.DomainBase;
namespace WebAppTemplateManager.Domain.Entities
{
    public partial class ModelType  : BaseEntity
    {
        private ModelType(){}
        public string ModelTypeName    { get; init; }  = string.Empty; 
        public string ModelTypeGroupName    { get; init; }  = string.Empty; 
        public ModelTypeGroup ModelTypeGroup    { get; init; } 
    //    private  List <Model> _Models { get;  set;}  = new List<Model>();
      //  public  IReadOnlyCollection<Model> Models => _Models;
        public Guid GuidId    { get; init; } 
        
        public static ModelType Create(string  modelTypeName, string  modelTypeGroupName, Guid  guidId)
    {
    if (guidId == Guid.Empty)
    {
        throw new ArgumentException($"ModelType Guid value cannot be empty {nameof(guidId)}");
    }
        return  new()
        {
            ModelTypeName = modelTypeName ,
            ModelTypeGroupName = modelTypeGroupName ,
            GuidId = guidId ,
        };
    }
    }
}