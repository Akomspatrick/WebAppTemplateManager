namespace DocumentVersionManager.Application.Contracts.RequestDTO
{
    public  record ApplicationRequestProductDTO();
    public  record ApplicationRequestProductByGuidDTO(Guid ProductGuid);
    public  record ApplicationRequestProductByIdDTO(string ProductId);
    public  record ApplicationCreateProductDTO();
    public  record ApplicationUpdateProductDTO(Guid ProductGuid);
    public  record ApplicationDeleteProductDTO(Guid ProductGuid);
}