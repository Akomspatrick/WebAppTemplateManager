using DocumentVersionManager.DomainBase.Base;


namespace DocumentVersionManager.Domain.Entities

{
    public partial class Product : BaseEntity
    {
        private Product()
        {
        }
        public static Product Create(int productId, int modelVersionId, string modelName, int capacity, DateTime timestamp, string stage, string subStage, string invoiceId, string salesOrderId, int cableLength, int inspectionResult, string defaultTestingMode, string usedCalibrationMode, string thermexPurcharseOrderNo, string machiningPurcharseOrderNo, string steelPurcharseOrderNo, string batcNo, ModelVersion modelVersion)
        {
            return new Product()
            {
                ProductId = productId,
                ModelVersionId = modelVersionId,
                ModelName = modelName,
                Capacity = capacity,
                Timestamp = timestamp,
                Stage = stage,
                SubStage = subStage,
                InvoiceId = invoiceId,
                SalesOrderId = salesOrderId,
                CableLength = cableLength,
                InspectionResult = inspectionResult,
                DefaultTestingMode = defaultTestingMode,
                UsedCalibrationMode = usedCalibrationMode,
                ThermexPurcharseOrderNo = thermexPurcharseOrderNo,
                MachiningPurcharseOrderNo = machiningPurcharseOrderNo,
                SteelPurcharseOrderNo = steelPurcharseOrderNo,
                BatcNo = batcNo,
                ModelVersion = modelVersion,
            };
        }

    }
}