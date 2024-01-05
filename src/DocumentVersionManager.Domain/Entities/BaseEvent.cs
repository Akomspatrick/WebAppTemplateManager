using DocumentVersionManager.DomainBase;
namespace DocumentVersionManager.Domain.Entities
{
    public class BaseEvent : BaseEntity
    {
        // public int ProductId { get; init; }
        //public Product Product { get; init; }
        public string UserName { get; init; } = string.Empty;
        public DateTime TimeStamp { get; init; }
        public Guid GuidId { get; init; }
    }
}