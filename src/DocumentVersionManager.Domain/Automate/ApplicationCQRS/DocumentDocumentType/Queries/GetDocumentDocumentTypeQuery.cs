using DocumentVersionManager.Application.Contracts.RequestDTO;
using DocumentVersionManager.Application.Contracts.ResponseDTO;
using DocumentVersionManager.Domain.Errors;
using LanguageExt;
using MediatR;
namespace DocumentVersionManager.Application.CQRS.DocumentDocumentType.Queries
{
    public  record GetDocumentDocumentTypeQuery(ApplicationDocumentDocumentTypeGetRequestDTO  RequestDocumentDocumentTypeDTO) :  IRequest<Either<GeneralFailure, ApplicationDocumentDocumentTypeResponseDTO>>;
}