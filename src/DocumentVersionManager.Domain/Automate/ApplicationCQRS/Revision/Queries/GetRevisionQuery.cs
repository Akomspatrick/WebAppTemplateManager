using DocumentVersionManager.Application.Contracts.RequestDTO;
using DocumentVersionManager.Application.Contracts.ResponseDTO;
using DocumentVersionManager.Domain.Errors;
using LanguageExt;
using MediatR;
namespace DocumentVersionManager.Application.CQRS.Revision.Queries
{
    public  record GetRevisionQuery(ApplicationRequestRevisionDTO  RequestRevisionDTO) :  IRequest<Either<GeneralFailure, ApplicationResponseRevisionDTO>>;
}