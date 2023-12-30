using DocumentVersionManager.Contracts.RequestDTO;
using DocumentVersionManager.Contracts.ResponseDTO;
using DocumentVersionManager.Domain.Errors;
using LanguageExt;
using MediatR;
namespace DocumentVersionManager.Application.CQRS.DocumentType.Queries{
    public  record GetDocumentTypeQuery(DocumentTypeGetRequestDTO  RequestDocumentTypeDTO) :  IRequest<Either<GeneralFailure, DocumentTypeResponseDTO>>;
    public  record GetDocumentTypeByGuidQuery(DocumentTypeGetRequestByGuidDTO  RequestDocumentTypeDTO) :  IRequest<Either<GeneralFailure, DocumentTypeResponseDTO>>;
    public  record GetDocumentTypeByIdQuery(DocumentTypeGetRequestByIdDTO  RequestDocumentTypeDTO) :  IRequest<Either<GeneralFailure, DocumentTypeResponseDTO>>;
    public  record GetAllDocumentTypeQuery :  IRequest<Either<GeneralFailure, IEnumerable<DocumentTypeResponseDTO>>>;
}