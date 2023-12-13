using DocumentVersionManager.Application.Contracts.RequestDTO;
using DocumentVersionManager.Application.Contracts.ResponseDTO;
using DocumentVersionManager.Domain.Errors;
using LanguageExt;
using MediatR;
namespace DocumentVersionManager.Application.CQRS.TestPoint.Queries
{
    public  record GetTestPointQuery(ApplicationRequestTestPointDTO  RequestTestPointDTO) :  IRequest<Either<GeneralFailure, ApplicationResponseTestPointDTO>>;
}