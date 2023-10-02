using DocumentVersionManager.Application.Commands;
using DocumentVersionManager.Contracts.RequestDTO;
using DocumentVersionManager.Domain.ModelAggregateRoot.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

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
            if (request == null)
            {
                var modeltype = new Application.ApplicationDTO.RequestDTO.ModelTypeDTO(request.ModelTypeName);
                var command = new AddNewModelTypeCommand(modeltype);
                await _mediator.Send(command);
            }

            return null;
        }
    }
}
