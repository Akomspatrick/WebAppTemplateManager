using DocumentVersionManager.DomainBase.Base;
namespace DocumentVersionManager.Domain.Entities
{
    using System.ComponentModel.DataAnnotations;

    public partial class CapacityDocument  : BaseEntity
    {
        private CapacityDocument(){}
        public string ModelName    { get; init; }  = string.Empty; 
        public int Capacity    { get; init; } 
        public string DocumentPath    { get; init; }  = string.Empty; 
        public Guid GuidId    { get; init; } 
        
        public static CapacityDocument Create(string  modelName, int  capacity, string  documentPath, Guid  guidId)
    {
    if (guidId == Guid.Empty)
    {
        throw new ArgumentException($"CapacityDocument Guid value cannot be empty {nameof(guidId)}");
    }
        return  new()
        {
            ModelName = modelName ,
            Capacity = capacity ,
            DocumentPath = documentPath ,
            GuidId = guidId ,
        };
    }
    }
}