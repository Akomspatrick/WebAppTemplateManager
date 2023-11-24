using DocumentVersionManager.Application.Contracts.RequestDTO;
using DocumentVersionManager.Application.Contracts.ResponseDTO;
using DocumentVersionManager.Domain.Errors;
using LanguageExt;
using MediatR;
namespace DocumentVersionManager.Application.CQRS.HigherModel.Queries
{
    public  record GetAllHigherModelQuery(ApplicationRequestHigherModelDTO  RequestHigherModelDTO) :  IRequest<Either<GeneralFailures, IEnumerable<ApplicationResponseHigherModelDTO>>>;
}