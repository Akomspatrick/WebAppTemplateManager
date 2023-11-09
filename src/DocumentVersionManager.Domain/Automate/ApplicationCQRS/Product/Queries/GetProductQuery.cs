using DocumentVersionManager.Application.Contracts.RequestDTO;
"using DocumentVersionManager.Application.Contracts.ResponsetDTO;
using  DocumentVersionManager.Domain.Errors;
using DocumentVersionManager.Domain.Errors;
using LanguageExt;
using MediatR;
namespace DocumentVersionManager.Application.CQRS.Product.Queries
{
    public  record GetProductQuery(ApplicationRequestProductDTO : RequestProductDTO) :  IRequest<Either<GeneralFailures, ApplicationRequestProductDTO>>;
}