using DocumentVersionManager.DomainBase.Base;
namespace DocumentVersionManager.Domain.Entities
{
    public partial class Product  : BaseEntity
        {
            public int ProductId    { get; init; } 
            public int ModelVersionId    { get; init; } 
            public string ModelName    { get; init; }  = string.Empty; 
            public int Capacity    { get; init; } 
            public DateTime Timestamp    { get; init; } 
            public string Stage    { get; init; }  = string.Empty; 
            public string SubStage    { get; init; }  = string.Empty; 
            public string InvoiceId    { get; init; }  = string.Empty; 
            public string SalesOrderId    { get; init; }  = string.Empty; 
            public int CableLength    { get; init; } 
            public int Troubled    { get; init; } 
            public string TestingModeName    { get; init; }  = string.Empty; 
            public string ThermexPurcharseOrderNo    { get; init; }  = string.Empty; 
            public string MachiningPurcharseOrderNo    { get; init; }  = string.Empty; 
            public string SteelPurcharseOrderNo    { get; init; }  = string.Empty; 
            public string MetalCertificateNo    { get; init; }  = string.Empty; 
            public string BatcNo    { get; init; }  = string.Empty; 
            public ModelVersion ModelVersion    { get; init; } 
        }
}