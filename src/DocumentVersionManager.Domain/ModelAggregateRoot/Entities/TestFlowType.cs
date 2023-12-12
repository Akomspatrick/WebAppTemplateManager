using DocumentVersionManager.DomainBase.Base;
namespace DocumentVersionManager.Domain.Entities
{
    public partial class TestFlowType : BaseEntity
    {
        public int TestingModeId { get; init; }
        public string TestingMode { get; init; } = string.Empty;
        public Guid GuidId { get; init; }

        public static Product Create()
        {
            throw new Exception("Please implemenete later");
        }
    }
}