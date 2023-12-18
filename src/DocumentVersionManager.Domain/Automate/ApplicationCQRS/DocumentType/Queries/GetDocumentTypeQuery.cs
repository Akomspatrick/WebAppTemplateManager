using DocumentVersionManager.Application.Contracts.RequestDTO;
using DocumentVersionManager.Application.Contracts.ResponseDTO;
using DocumentVersionManager.Domain.Errors;
using LanguageExt;
using MediatR;
namespace DocumentVersionManager.Application.CQRS.DocumentType.Queries
{
    public  record GetDocumentTypeQuery(ApplicationDocumentTypeGetRequestDTO  RequestDocumentTypeDTO) :  IRequest<Either<GeneralFailure, ApplicationDocumentTypeResponseDTO>>;
}