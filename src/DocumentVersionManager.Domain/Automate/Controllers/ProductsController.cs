using DocumentVersionManager..Api.Extentions;
using DocumentVersionManager.Application.Contracts.RequestDTO;
using DocumentVersionManager.Application.Contracts.ResponseDTO;
using DocumentVersionManager.Application.CQRS.Product.Commands;
using DocumentVersionManager.Application.CQRS.Product.Queries;
using DocumentVersionManager.Contracts.RequestDTO;
using DocumentVersionManager.Contracts.ResponseDTO;
using DocumentVersionManager.Domain.Errors;
using LanguageExt;
using  MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading;
namespace DocumentVersionManager.Api.Controllers.v1
{
    public  class ProductsController  : DVBaseController<ProductsController>
    {
        public ProductsController(ILogger<ProductsController> logger, ISender sender) : base(logger, sender){}
        [HttpPost(template: DocumentVersionManagerAPIEndPoints.Product.Create, Name = DocumentVersionManagerAPIEndPoints.Product.Create)]
        public async Task<IActionResult> Create(ProductCreateDTO request, CancellationToken cancellationToken)
        {
            var dto = new ApplicationProductCreateDTO(request.);

            return dto.EnsureInputIsNotEmpty("Input Cannot be Empty")
                .Bind<Either<GeneralFailure, int>>(_ => (  CreateModelType(dto, cancellationToken).Result   ) )
                .Match<IActionResult>(Left: errors => new OkObjectResult(errors),
                    Right: result => result.Match<IActionResult>(
                    Left: errors2 => new OkObjectResult(errors2),Right: result2 => Created($"/{DocumentVersionManagerAPIEndPoints.Product.Create}/{dto}", dto)));
        }

        private async Task<Either<GeneralFailure, int>> CreateProduct(ApplicationProductCreateDTO createdDto, CancellationToken cancellationToken)
        => await _sender.Send(new CreateProductCommand(createdDto), cancellationToken);
    }
}