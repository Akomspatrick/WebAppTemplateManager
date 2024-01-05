namespace DocumentVersionManager.Application.Contracts.RequestDTO
{
    public  record ApplicationProductGetRequestByGuidDTO(ProductGetRequestByGuidDTO Value);
    public  record ApplicationProductGetRequestByIdDTO(ProductGetRequestByIdDTO Value);
    public  record ApplicationProductGetRequestDTO(ProductGetRequestDTO Value);
    public  record ApplicationProductCreateRequestDTO(ProductCreateRequestDTO Value );
    public  record ApplicationProductUpdateRequestDTO(ProductUpdateRequestDTO Value);
    public  record ApplicationProductDeleteRequestDTO(ProductDeleteRequestDTO Value);
}