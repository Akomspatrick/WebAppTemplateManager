using DocumentVersionManager.Application.Contracts.RequestDTO;
using DocumentVersionManager.Application.CQRS.HigherModel.Commands;
using DocumentVersionManager.Application.CQRS.ModelType.Commands;
using DocumentVersionManager.Contracts.RequestDTO;
using DocumentVersionManager.Domain.Errors;
using LanguageExt;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DocumentVersionManager.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HigherModelController : ControllerBase
    { 
        private readonly ILogger<HigherModelController> _logger;
        //private readonly IMediator _mediator;
        private readonly ISender _mediator;

        public HigherModelController(ILogger<HigherModelController> logger, ISender mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpPost(template: "PostHigherModel", Name = "PostEitherHigherModel")]
        public async Task<IActionResult> Post(HigherModelDTO request, CancellationToken cancellationToken)
        {

          //  var modelType = new ApplicationModelTypeRequestDTO(modelTypeDTO.ModelTypeName);
            var x = await _mediator.Send(new AddNewHigherModelCommand(request.HigherModelName,request.HigherModelDescription,request.ProductId, request.Capacity), cancellationToken);
            return Ok();

        }


        [HttpPost(template: "PostHigherModelMany", Name = "PostEitherHigherModelMany")]
        public async Task<IActionResult> PostEitherHigherModelMany( CancellationToken cancellationToken)
        {

            //  var modelType = new ApplicationModelTypeRequestDTO(modelTypeDTO.ModelTypeName);
             HigherModelDTO request = new HigherModelDTO("string", "string", "string", 1);
            var x = await _mediator.Send(new AddNewHigherModelCommand(request.HigherModelName, request.HigherModelDescription, request.ProductId, request.Capacity), cancellationToken);
            return Ok();

        }


        //[HttpPost(template: "PostHigherModelMany", Name = "PostEitherHigherModelMany")]
        //public async Task<IActionResult> PostEitherHigherModelMany(, CancellationToken cancellationToken)
        //{

        //    //  var modelType = new ApplicationModelTypeRequestDTO(modelTypeDTO.ModelTypeName);
        //    HigherModelDTO request = new HigherModelDTO("string", "string", "string", 1);
        //    var x = await _mediator.Send(new AddNewHigherModelCommand(request.HigherModelName, request.HigherModelDescription, request.ProductId, request.Capacity), cancellationToken);
        //    return Ok();

        //}

    }
}
