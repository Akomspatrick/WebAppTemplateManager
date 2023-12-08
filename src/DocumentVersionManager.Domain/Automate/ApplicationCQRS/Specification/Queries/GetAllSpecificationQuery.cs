using DocumentVersionManager.Application.Contracts.RequestDTO;
using DocumentVersionManager.Application.Contracts.ResponseDTO;
using DocumentVersionManager.Domain.Errors;
using LanguageExt;
using MediatR;
namespace DocumentVersionManager.Application.CQRS.Specification.Queries
{
    public  record GetAllSpecificationQuery(ApplicationRequestSpecificationDTO  RequestSpecificationDTO) :  IRequest<Either<GeneralFailure, IEnumerable<ApplicationResponseSpecificationDTO>>>;
}