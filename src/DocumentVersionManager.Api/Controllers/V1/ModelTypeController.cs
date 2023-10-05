using DocumentVersionManager.Api.Extentions;
using DocumentVersionManager.Application.Commands;
using DocumentVersionManager.Contracts.RequestDTO;
using DocumentVersionManager.Domain.Errors;
using DocumentVersionManager.Domain.ModelAggregateRoot.Entities;
using LanguageExt;
using LanguageExt.ClassInstances.Pred;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading;

namespace DocumentVersionManager.Api.Controllers.V1
{
    [ApiController]
    [Route("[controller]")]
    public class ModelTypeController : ControllerBase
    {
        private readonly ILogger<ModelTypeController> _logger;
        private readonly IMediator _mediator;

        public ModelTypeController(ILogger<ModelTypeController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        //[HttpGet(Name = "GetAllModelTypes/Yes")]
        //public IEnumerable<Contracts.RequestDTO.ModelTypeDTO> Get()
        //{
        //    return null;
        //}

        //[HttpGet("/SomeAllModelTypes/ALL")]
        //public IEnumerable<Contracts.RequestDTO.ModelTypeDTO> Some()
        //{
        //    return null;
        //}


        [HttpPost(Name = "Add")]
        public async Task<IEnumerable<ModelTypeDTO>> Post(ModelTypeDTO request)
        {
            // var modeltype = new ModelType { ModelTypeName = request.ModelTypeName.ToString() }; 
            if (request != null)
            {
                // convert apidto to applicationdto so that api doesnt leak into application layer.
                var modeltype = new Application.ApplicationDTO.RequestDTO.ModelTypeDTO(request.ModelTypeName);
                var command = new AddNewModelTypeCommand(modeltype);
                var result = await _mediator.Send(command);
            }

            return null;
        }
        /*
         *       [HttpPost("PostEither")]
        public async Task<IEnumerable<ModelTypeDTO>> PostEither(ModelTypeDTO request, CancellationToken cancellationToken)
        {
            // var modeltype = new ModelType { ModelTypeName = request.ModelTypeName.ToString() }; 
            if (request != null)
            {
                var x = request.EnsureInputIsNotNull("Input Cannot be null").Bind<Either<ModelFailures, int>>(_ => AddModelType(request, cancellationToken));
                var y = request.EnsureInputIsNotNull("Input Cannot be null").Bind(_ => AddModelType(request, cancellationToken));


            }
            return null;
        }

        private Either<ModelFailures, int> AddModelType(ModelTypeDTO modelTypeDTO, CancellationToken cancellationToken)
        {

            var modelType = new Application.ApplicationDTO.RequestDTO.ModelTypeDTO(modelTypeDTO.ModelTypeName);
            var x = _mediator.Send(new AddNewModelTypeCommand(modelType), cancellationToken);
            return x.Result;
        }
          */
        [HttpPost("PostEither")]
        public async Task<IActionResult> PostEither(ModelTypeDTO request, CancellationToken cancellationToken)
        {

            if (request != null)
            {
                var x = request.EnsureInputIsNotNull("Input Cannot be null").Bind<Either<ModelFailures, int>>(request => AddModelType(request, cancellationToken).Result);
                //var result 
                return null;
            }
            return null;
        }

        private async Task<Either<ModelFailures, int>> AddModelType(ModelTypeDTO modelTypeDTO, CancellationToken cancellationToken)
        {

            var modelType = new Application.ApplicationDTO.RequestDTO.ModelTypeDTO(modelTypeDTO.ModelTypeName);
            var x = await _mediator.Send(new AddNewModelTypeCommand(modelType), cancellationToken);
            return x;
        }

        [HttpPost("PostEither2")]
        public async Task<IActionResult> PostEither2(ModelTypeDTO request, CancellationToken cancellationToken)
        {


                var x = request.EnsureInputIsNotNull("Input Cannot be null").Bind<Either<ModelFailures, int>>(request => AddModelType(request, cancellationToken).Result);
                return x.Match<IActionResult>(
                                       Left: errors => new BadRequestObjectResult(errors),
                                                          Right: result => new OkObjectResult(result)
                                                                             );
        }


    }
}
