using DocumentVersionManager.Application.Contracts.RequestDTO;
using DocumentVersionManager.Application.Contracts.ResponseDTO;
using DocumentVersionManager.Domain.Errors;
using LanguageExt;
using MediatR;
namespace DocumentVersionManager.Application.CQRS.ModelTypes.Queries
{
    public  record GetModelTypesQuery(ApplicationRequestModelTypesDTO  RequestModelTypesDTO) :  IRequest<Either<GeneralFailure, ApplicationResponseModelTypesDTO>>;
}