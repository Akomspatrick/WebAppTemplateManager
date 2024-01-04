using DocumentVersionManager.Application.Contracts.RequestDTO;
using DocumentVersionManager.Application.Contracts.ResponseDTO;
using DocumentVersionManager.Domain.Errors;
using LanguageExt;
using MediatR;
namespace DocumentVersionManager.Application.CQRS.DocumentDocumentType.Queries{
    public  record GetDocumentDocumentTypeQuery(ApplicationDocumentDocumentTypeGetRequestDTO  RequestDocumentDocumentTypeDTO) :  IRequest<Either<GeneralFailure, ApplicationDocumentDocumentTypeResponseDTO>>;
    public  record GetDocumentDocumentTypeByGuidQuery(ApplicationDocumentDocumentTypeGetRequestByGuidDTO  RequestDocumentDocumentTypeDTO) :  IRequest<Either<GeneralFailure, ApplicationDocumentDocumentTypeResponseDTO>>;
    public  record GetDocumentDocumentTypeByIdQuery(ApplicationDocumentDocumentTypeGetRequestByIdDTO  RequestDocumentDocumentTypeDTO) :  IRequest<Either<GeneralFailure, ApplicationDocumentDocumentTypeResponseDTO>>;
    public  record GetAllDocumentDocumentTypeQuery :  IRequest<Either<GeneralFailure, IEnumerable<ApplicationDocumentDocumentTypeResponseDTO>>>;
}