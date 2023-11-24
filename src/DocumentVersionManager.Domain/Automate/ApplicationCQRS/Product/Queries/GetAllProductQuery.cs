using DocumentVersionManager.Application.Contracts.RequestDTO;
using DocumentVersionManager.Application.Contracts.ResponseDTO;
using DocumentVersionManager.Domain.Errors;
using LanguageExt;
using MediatR;
namespace DocumentVersionManager.Application.CQRS.Product.Queries
{
    public  record GetAllProductQuery(ApplicationRequestProductDTO  RequestProductDTO) :  IRequest<Either<GeneralFailures, IEnumerable<ApplicationResponseProductDTO>>>;
}