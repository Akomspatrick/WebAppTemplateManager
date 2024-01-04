using DocumentVersionManager.Application.Contracts.RequestDTO;
using DocumentVersionManager.Application.Contracts.ResponseDTO;
using DocumentVersionManager.Domain.Errors;
using LanguageExt;
using MediatR;
namespace DocumentVersionManager.Application.CQRS.Document.Queries{
    public  record GetDocumentQuery(ApplicationDocumentGetRequestDTO  RequestDocumentDTO) :  IRequest<Either<GeneralFailure, ApplicationDocumentResponseDTO>>;
    public  record GetDocumentByGuidQuery(ApplicationDocumentGetRequestByGuidDTO  RequestDocumentDTO) :  IRequest<Either<GeneralFailure, ApplicationDocumentResponseDTO>>;
    public  record GetDocumentByIdQuery(ApplicationDocumentGetRequestByIdDTO  RequestDocumentDTO) :  IRequest<Either<GeneralFailure, ApplicationDocumentResponseDTO>>;
    public  record GetAllDocumentQuery :  IRequest<Either<GeneralFailure, IEnumerable<ApplicationDocumentResponseDTO>>>;
}