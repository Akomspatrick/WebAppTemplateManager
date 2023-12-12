using DocumentVersionManager.Application.Contracts.RequestDTO;
using DocumentVersionManager.Application.Contracts.ResponseDTO;
using DocumentVersionManager.Domain.Errors;
using LanguageExt;
using MediatR;
namespace DocumentVersionManager.Application.CQRS.ModelType.Queries
{
    public  record GetModelTypeQuery(ApplicationRequestModelTypeDTO  RequestModelTypeDTO) :  IRequest<Either<GeneralFailure, ApplicationResponseModelTypeDTO>>;
}