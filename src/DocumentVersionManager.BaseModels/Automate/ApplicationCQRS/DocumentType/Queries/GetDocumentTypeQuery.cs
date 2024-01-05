using DocumentVersionManager.Application.Contracts.RequestDTO;
using DocumentVersionManager.Application.Contracts.ResponseDTO;
using DocumentVersionManager.Domain.Errors;
using LanguageExt;
using MediatR;
namespace DocumentVersionManager.Application.CQRS.DocumentType.Queries{
    public  record GetDocumentTypeQuery(ApplicationDocumentTypeGetRequestDTO  RequestDocumentTypeDTO) :  IRequest<Either<GeneralFailure, ApplicationDocumentTypeResponseDTO>>;
    public  record GetDocumentTypeByGuidQuery(ApplicationDocumentTypeGetRequestByGuidDTO  RequestDocumentTypeDTO) :  IRequest<Either<GeneralFailure, ApplicationDocumentTypeResponseDTO>>;
    public  record GetDocumentTypeByIdQuery(ApplicationDocumentTypeGetRequestByIdDTO  RequestDocumentTypeDTO) :  IRequest<Either<GeneralFailure, ApplicationDocumentTypeResponseDTO>>;
    public  record GetAllDocumentTypeQuery :  IRequest<Either<GeneralFailure, IEnumerable<ApplicationDocumentTypeResponseDTO>>>;
}