namespace DocumentVersionManager.BaseModels.Entities
{
    public class Product
    {
        public required int SerialNo { get; init; }

        public required string ModelName { get; init; } = string.Empty;
        public required int Capacity { get; init; }
        public required DateTime Timestamp { get; init; }

        public required string CurrentStage { get; init; } = string.Empty;
        public required string NextStage { get; init; } = string.Empty;//stage

        public string SubStage { get; init; } = string.Empty;

        public string InvoiceId { get; init; } = string.Empty;
        public string SalesOrderId { get; init; } = string.Empty;

        public required int CableLength { get; init; } = 0;
        public required int Troubled { get; init; } = 0;


    }
}
