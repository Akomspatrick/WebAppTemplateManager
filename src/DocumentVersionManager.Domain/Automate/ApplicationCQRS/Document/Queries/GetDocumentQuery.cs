using DocumentVersionManager.Contracts.RequestDTO;
using DocumentVersionManager.Contracts.ResponseDTO;
using DocumentVersionManager.Domain.Errors;
using LanguageExt;
using MediatR;
namespace DocumentVersionManager.Application.CQRS.Document.Queries{
    public  record GetDocumentQuery(DocumentGetRequestDTO  RequestDocumentDTO) :  IRequest<Either<GeneralFailure, DocumentResponseDTO>>;
    public  record GetDocumentByGuidQuery(DocumentGetRequestByGuidDTO  RequestDocumentDTO) :  IRequest<Either<GeneralFailure, DocumentResponseDTO>>;
    public  record GetDocumentByIdQuery(DocumentGetRequestByIdDTO  RequestDocumentDTO) :  IRequest<Either<GeneralFailure, DocumentResponseDTO>>;
    public  record GetAllDocumentQuery :  IRequest<Either<GeneralFailure, IEnumerable<DocumentResponseDTO>>>;
}