using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentVersionManager.Application.Behaviours
{
    public class LoggingPipelineBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
        //   where TResponse:Result // Specify the type of Result 
    {
        private readonly ILogger<LoggingPipelineBehaviour<TRequest, TResponse>> _logger;

        public LoggingPipelineBehaviour(ILogger<LoggingPipelineBehaviour<TRequest, TResponse>> logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            // This can be used to log request and responses through the application

            _logger.LogInformation("Starting request {@RequestName}, {@DateTimeUtc} ", typeof(TRequest).Name, DateTime.UtcNow);

            var result = await next();
            //if (result != null)
            //{
            // you can check if result is failure here if you are using railway approch 
            // e.g if result.failure ... log failure
            //}
            _logger.LogInformation("Completed request {@RequestName}, {@DateTimeUtc} ", typeof(TRequest).Name, DateTime.UtcNow);


            return result;
        }
    }
}
