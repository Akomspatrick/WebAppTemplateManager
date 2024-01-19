using DocumentVersionManager.Contracts.RequestDTO;
using DocumentVersionManager.Contracts.ResponseDTO;
using DocumentVersionManager.Domain.Errors;
using LanguageExt;
using MediatR;
namespace DocumentVersionManager.Application.CQRS.DocumentBasePath.Queries{
    public  record GetDocumentBasePathQuery(DocumentBasePathGetRequestDTO  RequestDocumentBasePathDTO) :  IRequest<Either<GeneralFailure, DocumentBasePathResponseDTO>>;
    public  record GetDocumentBasePathByGuidQuery(DocumentBasePathGetRequestByGuidDTO  RequestDocumentBasePathDTO) :  IRequest<Either<GeneralFailure, DocumentBasePathResponseDTO>>;
    public  record GetDocumentBasePathByIdQuery(DocumentBasePathGetRequestByIdDTO  RequestDocumentBasePathDTO) :  IRequest<Either<GeneralFailure, DocumentBasePathResponseDTO>>;
    public  record GetAllDocumentBasePathQuery :  IRequest<Either<GeneralFailure, IEnumerable<DocumentBasePathResponseDTO>>>;
}