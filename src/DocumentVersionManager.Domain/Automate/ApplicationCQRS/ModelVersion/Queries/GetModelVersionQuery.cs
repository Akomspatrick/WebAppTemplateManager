using DocumentVersionManager.Application.Contracts.RequestDTO;
using DocumentVersionManager.Application.Contracts.ResponseDTO;
using DocumentVersionManager.Domain.Errors;
using LanguageExt;
using MediatR;
namespace DocumentVersionManager.Application.CQRS.ModelVersion.Queries
{
    public  record GetModelVersionQuery(ApplicationRequestModelVersionDTO  RequestModelVersionDTO) :  IRequest<Either<GeneralFailure, ApplicationResponseModelVersionDTO>>;
}