using DocumentVersionManager.DomainBase.Base;
namespace DocumentVersionManager.Domain.Entities
{
    public partial class HigherModel  : BaseEntity
        {
            public string HigherModelName    { get; init; }  = string.Empty; 
            public string HigherModelDescription    { get; init; }  = string.Empty; 
            public string ProductId    { get; init; }  = string.Empty; 
            public int Capacity    { get; init; } 
            public string Id    { get; init; }  = string.Empty; 
            public Guid GuidId    { get; init; } 
        }
}