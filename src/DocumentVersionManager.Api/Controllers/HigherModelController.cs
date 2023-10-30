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
        //private readonly IMediator _sender;
        private readonly ISender _sender;

        public HigherModelController(ILogger<HigherModelController> logger, ISender sender)
        {
            _logger = logger;
            _sender = sender;
        }

        [HttpPost(template: "PostHigherModel", Name = "PostEitherHigherModel")]
        public async Task<IActionResult> Post(HigherModelDTO request, CancellationToken cancellationToken)
        {

            //  var modelType = new ApplicationModelTypeRequestDTO(modelTypeDTO.modelTypesName);
            var x = await _sender.Send(new AddNewHigherModelCommand(request.HigherModelName, request.HigherModelDescription, request.ProductId, request.Capacity), cancellationToken);
            return Ok();

        }


        [HttpPost(template: "PostHigherModelMany", Name = "PostEitherHigherModelMany")]
        public async Task<IActionResult> PostEitherHigherModelMany(CancellationToken cancellationToken)
        {

            //  var modelType = new ApplicationModelTypeRequestDTO(modelTypeDTO.modelTypesName);
            HigherModelDTO request = new HigherModelDTO("string", "string", "string", 1);
            var x = await _sender.Send(new AddNewHigherModelCommand(request.HigherModelName, request.HigherModelDescription, request.ProductId, request.Capacity), cancellationToken);
            return Ok();

        }


        //[HttpPost(template: "PostHigherModelMany", Name = "PostEitherHigherModelMany")]
        //public async Task<IActionResult> PostEitherHigherModelMany(, CancellationToken cancellationToken)
        //{

        //    //  var modelType = new ApplicationModelTypeRequestDTO(modelTypeDTO.modelTypesName);
        //    HigherModelDTO request = new HigherModelDTO("string", "string", "string", 1);
        //    var x = await _sender.Send(new AddNewHigherModelCommand(request.HigherModelName, request.HigherModelDescription, request.ProductId, request.Capacity), cancellationToken);
        //    return Ok();

        //}

    }
}
