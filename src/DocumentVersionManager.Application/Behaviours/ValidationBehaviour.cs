using DocumentVersionManager.Application.CQRS.ModelType.Commands;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DocumentVersionManager.Application.Behaviours
{
    public class ValidationModelTypeBehaviour : IPipelineBehavior<CreateModelTypeCommand, int>
    {
        private readonly IValidator<CreateModelTypeCommand> _validator;

        public ValidationModelTypeBehaviour(IValidator<CreateModelTypeCommand> validator)
        {
            _validator = validator;
        }

        public async Task<int> Handle(CreateModelTypeCommand request, RequestHandlerDelegate<int> next, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(request, cancellationToken);
            if (validationResult.IsValid)
            {
                return await next();
            }
            var result = await next();
            return result;
        }
    }
}
