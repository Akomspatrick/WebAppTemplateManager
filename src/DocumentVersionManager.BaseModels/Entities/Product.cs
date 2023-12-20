namespace DocumentVersionManager.BaseModels.Entities
{
    public class Product
    {
        public required int ProductId { get; init; } // SerialNo
        public int ModelVersionId { get; init; }
        public required string ModelName { get; init; } = string.Empty;
        public required int Capacity { get; init; }
        public required DateTime Timestamp { get; init; }
        public required string Stage { get; init; } = string.Empty;
        public string SubStage { get; init; } = string.Empty;
        //public string InvoiceId { get; init; } = string.Empty;
        public string SalesOrderId { get; init; } = string.Empty;
        public required int CableLength { get; init; } = 0;
        public required int InspectionResult { get; init; } = 0;
        public string DefaultTestingMode { get; init; } = string.Empty; // Manual, Automatic from the Model Version
        public string UsedCalibrationMode { get; init; } = string.Empty; // Manual, Automatic from the Model Type
        public string ThermexPurcharseOrderNo { get; init; } = string.Empty;
        public string MachiningPurcharseOrderNo { get; init; } = string.Empty;
        public string SteelPurcharseOrderNo { get; init; } = string.Empty;

        public string BatcNo { get; init; } = string.Empty;

        public ModelVersion? ModelVersion { get; init; }



    }
}
