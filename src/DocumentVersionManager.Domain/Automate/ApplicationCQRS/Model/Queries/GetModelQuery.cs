using DocumentVersionManager.Application.Contracts.RequestDTO;
using DocumentVersionManager.Application.Contracts.ResponseDTO;
using DocumentVersionManager.Domain.Errors;
using LanguageExt;
using MediatR;
namespace DocumentVersionManager.Application.CQRS.Model.Queries
{
    public  record GetModelQuery(ApplicationModelGetRequestDTO  RequestModelDTO) :  IRequest<Either<GeneralFailure, ApplicationModelResponseDTO>>;
}