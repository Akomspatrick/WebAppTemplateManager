namespace DocumentVersionManager.BaseModels.Entities
{
    public class TestFlowType : BaseEntity
    {
        public int TestingModeId { get; init; }

        public string TestingMode { get; init; } = string.Empty;
        public string Description { get; init; } = string.Empty;




    }
}
