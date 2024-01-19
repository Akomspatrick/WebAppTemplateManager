using DocumentVersionManager.DomainBase;
namespace DocumentVersionManager.Domain.Entities
{
    public partial class Product  : BaseEntity
    {
        private Product(){}
        public int ProductId    { get; init; } 
        public int ModelVersionId    { get; init; } 
        public string ModelName    { get; init; }  = string.Empty; 
        public int Capacity    { get; init; } 
        public DateTime Timestamp    { get; init; } 
        public string Stage    { get; init; }  = string.Empty; 
        public string SubStage    { get; init; }  = string.Empty; 
        public string SalesOrderId    { get; init; }  = string.Empty; 
        public int CableLength    { get; init; } 
        public int InspectionResult    { get; init; } 
        public string DefaultTestingMode    { get; init; }  = string.Empty; 
        public string ModelTypeGroupName    { get; init; }  = string.Empty; 
        public string UsedTestingMode    { get; init; }  = string.Empty; 
        public string ThermexPurcharseOrderNo    { get; init; }  = string.Empty; 
        public string MachiningPurcharseOrderNo    { get; init; }  = string.Empty; 
        public string SteelPurcharseOrderNo    { get; init; }  = string.Empty; 
        public int BatcNo    { get; init; } 
        public ModelVersion ModelVersion    { get; init; } 
        public Guid GuidId    { get; init; } 
        
        public static Product Create(int  productId, int  modelVersionId, string  modelName, int  capacity, DateTime  timestamp, string  stage, string  subStage, string  salesOrderId, int  cableLength, int  inspectionResult, string  defaultTestingMode, string  modelTypeGroupName, string  usedTestingMode, string  thermexPurcharseOrderNo, string  machiningPurcharseOrderNo, string  steelPurcharseOrderNo, int  batcNo, Guid  guidId)
    {
    if (guidId == Guid.Empty)
    {
        throw new ArgumentException($"Product Guid value cannot be empty {nameof(guidId)}");
    }
        return  new()
        {
            ProductId = productId ,
            ModelVersionId = modelVersionId ,
            ModelName = modelName ,
            Capacity = capacity ,
            Timestamp = timestamp ,
            Stage = stage ,
            SubStage = subStage ,
            SalesOrderId = salesOrderId ,
            CableLength = cableLength ,
            InspectionResult = inspectionResult ,
            DefaultTestingMode = defaultTestingMode ,
            ModelTypeGroupName = modelTypeGroupName ,
            UsedTestingMode = usedTestingMode ,
            ThermexPurcharseOrderNo = thermexPurcharseOrderNo ,
            MachiningPurcharseOrderNo = machiningPurcharseOrderNo ,
            SteelPurcharseOrderNo = steelPurcharseOrderNo ,
            BatcNo = batcNo ,
            GuidId = guidId ,
        };
    }
    }
}