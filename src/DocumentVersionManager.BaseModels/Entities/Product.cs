using CodeGeneratorAttributesLibrary;

namespace DocumentVersionManager.BaseModels.Entities
{
    [BaseModelsForeignKeyAttribute("ModelVersion", "Products")]
    public class Product : BaseEntity
    {
        [BaseModelBasicAttribute(true)]
        public required int ProductId { get; init; } // SerialNo

        [BaseModelBasicAttribute(false, true)]
        public int ModelVersionId { get; init; }

        [BaseModelBasicAttribute(32, 0, false, true, false)]
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
        public string ModelTypeGroupName { get; init; } = string.Empty;// DefaultTestingMode and ModelTypeGroupName should be taken from the ModelTypeGroup via ModelType
        public string UsedTestingMode { get; init; } = string.Empty; // Manual, Automatic from the Model Type
        public string ThermexPurcharseOrderNo { get; init; } = string.Empty;
        public string MachiningPurcharseOrderNo { get; init; } = string.Empty;
        public string SteelPurcharseOrderNo { get; init; } = string.Empty;

        public int BatcNo { get; init; }

        public ModelVersion? ModelVersion { get; init; }



    }
}
