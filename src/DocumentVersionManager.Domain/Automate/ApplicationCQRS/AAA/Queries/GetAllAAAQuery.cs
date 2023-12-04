using DocumentVersionManager.Application.Contracts.RequestDTO;
using DocumentVersionManager.Application.Contracts.ResponseDTO;
using DocumentVersionManager.Domain.Errors;
using LanguageExt;
using MediatR;
namespace DocumentVersionManager.Application.CQRS.AAA.Queries
{
    public  record GetAllAAAQuery(ApplicationRequestAAADTO  RequestAAADTO) :  IRequest<Either<GeneralFailures, IEnumerable<ApplicationResponseAAADTO>>>;
}