using DocumentVersionManager.Api.Extentions;
using DocumentVersionManager.Application.CQRS.Product.Commands;
using DocumentVersionManager.Application.CQRS.Product.Queries;
using DocumentVersionManager.Contracts.RequestDTO;
using DocumentVersionManager.Contracts.ResponseDTO;
using DocumentVersionManager.Domain.Errors;
using LanguageExt;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading;
namespace DocumentVersionManager.Api.Controllers.v1
{
    public  class ProductsController  : TheBaseController<ProductsController>
    {

        public ProductsController(ILogger<ProductsController> logger, ISender sender) : base(logger, sender){}

        [ProducesResponseType(typeof(IEnumerable<ProductResponseDTO>), StatusCodes.Status200OK)]
        [HttpGet(template: DocumentVersionManagerAPIEndPoints.Product.Get, Name = DocumentVersionManagerAPIEndPoints.Product.Get)]
        public Task<IActionResult> Get(CancellationToken cToken) => _sender.Send(new GetAllProductQuery(), cToken).ToActionResult();

        [ProducesResponseType(typeof(ProductResponseDTO), StatusCodes.Status200OK)]
        [HttpGet(template: DocumentVersionManagerAPIEndPoints.Product.GetById, Name = DocumentVersionManagerAPIEndPoints.Product.GetById)]
        public Task<IActionResult> GetById([FromRoute] string NameOrGuid, CancellationToken cancellationToken)
        {
            return Guid.TryParse(NameOrGuid, out Guid guid)  ?
                (_sender.Send(new GetProductByGuidQuery(new ProductGetRequestByGuidDTO(guid)), cancellationToken)).ToActionResult404()
                :
                (_sender.Send(new GetProductByIdQuery(new ProductGetRequestByIdDTO(NameOrGuid)), cancellationToken)).ToActionResult404();
        }

        [ProducesResponseType(typeof(ModelTypeResponseDTO), StatusCodes.Status200OK)]
        [HttpGet(template: DocumentVersionManagerAPIEndPoints.Product.GetByJSONBody, Name = DocumentVersionManagerAPIEndPoints.Product.GetByJSONBody)]
        public Task<IActionResult> GetByJSONBody([FromBody] ProductGetRequestDTO request, CancellationToken cancellationToken)
                => ( _sender.Send(new GetProductQuery(request), cancellationToken)) .ToActionResult404();

        [HttpPost(template: DocumentVersionManagerAPIEndPoints.Product.Create, Name = DocumentVersionManagerAPIEndPoints.Product.Create)]
        public Task<IActionResult> Create(ProductCreateRequestDTO request, CancellationToken cancellationToken)
             => (_sender.Send(new CreateProductCommand(request), cancellationToken)).ToActionResultCreated($"{DocumentVersionManagerAPIEndPoints.Product.Create}", request);

        [HttpPut(template: DocumentVersionManagerAPIEndPoints.Product.Update, Name = DocumentVersionManagerAPIEndPoints.Product.Update)]
        public Task<IActionResult> Update(ProductUpdateRequestDTO request, CancellationToken cancellationToken)
            => (_sender.Send(new UpdateProductCommand(request), cancellationToken)) .ToActionResultCreated($"{DocumentVersionManagerAPIEndPoints.Product.Create}", request);


        [HttpDelete(template: DocumentVersionManagerAPIEndPoints.Product.Delete, Name = DocumentVersionManagerAPIEndPoints.Product.Delete)]
        public Task<IActionResult> Delete([FromRoute] Guid request, CancellationToken cancellationToken)
            =>_sender.Send(new DeleteProductCommand(new ProductDeleteRequestDTO(request)), cancellationToken).ToActionResult();

    }
}