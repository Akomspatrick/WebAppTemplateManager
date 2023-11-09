namespace DocumentVersionManager.Domain.BaseModels.Entities
{
    public  class Product  : BaseEntity
        {
            public int SerialNo    { get; init; } 
            public string ModelName    { get; init; }  = string.Empty; 
            public int Capacity    { get; init; } 
            public DateTime Timestamp    { get; init; } 
            public string CurrentStage    { get; init; }  = string.Empty; 
            public string NextStage    { get; init; }  = string.Empty; 
            public string SubStage    { get; init; }  = string.Empty; 
            public string InvoiceId    { get; init; }  = string.Empty; 
            public string SalesOrderId    { get; init; }  = string.Empty; 
            public int CableLength    { get; init; } 
            public int Troubled    { get; init; } 
        }
}