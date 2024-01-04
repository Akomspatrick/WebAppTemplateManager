using DocumentVersionManager.Application.Contracts.RequestDTO;
using DocumentVersionManager.Application.Contracts.ResponseDTO;
using DocumentVersionManager.Domain.Errors;
using LanguageExt;
using MediatR;
namespace DocumentVersionManager.Application.CQRS.DocumentBasePath.Queries{
    public  record GetDocumentBasePathQuery(ApplicationDocumentBasePathGetRequestDTO  RequestDocumentBasePathDTO) :  IRequest<Either<GeneralFailure, ApplicationDocumentBasePathResponseDTO>>;
    public  record GetDocumentBasePathByGuidQuery(ApplicationDocumentBasePathGetRequestByGuidDTO  RequestDocumentBasePathDTO) :  IRequest<Either<GeneralFailure, ApplicationDocumentBasePathResponseDTO>>;
    public  record GetDocumentBasePathByIdQuery(ApplicationDocumentBasePathGetRequestByIdDTO  RequestDocumentBasePathDTO) :  IRequest<Either<GeneralFailure, ApplicationDocumentBasePathResponseDTO>>;
    public  record GetAllDocumentBasePathQuery :  IRequest<Either<GeneralFailure, IEnumerable<ApplicationDocumentBasePathResponseDTO>>>;
}