namespace DocumentVersionManager.Application.Contracts.RequestDTO
{
    public  record ApplicationTestPointGetRequestByGuidDTO(TestPointGetRequestByGuidDTO Value);
    public  record ApplicationTestPointGetRequestByIdDTO(TestPointGetRequestByIdDTO Value);
    public  record ApplicationTestPointGetRequestDTO(TestPointGetRequestDTO Value);
    public  record ApplicationTestPointCreateRequestDTO(TestPointCreateRequestDTO Value );
    public  record ApplicationTestPointUpdateRequestDTO(TestPointUpdateRequestDTO Value);
    public  record ApplicationTestPointDeleteRequestDTO(TestPointDeleteRequestDTO Value);
}