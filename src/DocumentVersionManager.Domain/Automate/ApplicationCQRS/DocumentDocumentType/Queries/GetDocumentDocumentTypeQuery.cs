using DocumentVersionManager.Contracts.RequestDTO;
using DocumentVersionManager.Contracts.ResponseDTO;
using DocumentVersionManager.Domain.Errors;
using LanguageExt;
using MediatR;
namespace DocumentVersionManager.Application.CQRS.DocumentDocumentType.Queries{
    public  record GetDocumentDocumentTypeQuery(DocumentDocumentTypeGetRequestDTO  RequestDocumentDocumentTypeDTO) :  IRequest<Either<GeneralFailure, DocumentDocumentTypeResponseDTO>>;
    public  record GetDocumentDocumentTypeByGuidQuery(DocumentDocumentTypeGetRequestByGuidDTO  RequestDocumentDocumentTypeDTO) :  IRequest<Either<GeneralFailure, DocumentDocumentTypeResponseDTO>>;
    public  record GetDocumentDocumentTypeByIdQuery(DocumentDocumentTypeGetRequestByIdDTO  RequestDocumentDocumentTypeDTO) :  IRequest<Either<GeneralFailure, DocumentDocumentTypeResponseDTO>>;
    public  record GetAllDocumentDocumentTypeQuery :  IRequest<Either<GeneralFailure, IEnumerable<DocumentDocumentTypeResponseDTO>>>;
}