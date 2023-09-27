using DocumentVersionManager.Application.Commands;
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
    public class ValidationModelTypeBehaviour : IPipelineBehavior<AddNewModelTypeCommand, int>
    {
        private readonly IValidator<AddNewModelTypeCommand> _validator;

        public ValidationModelTypeBehaviour(IValidator<AddNewModelTypeCommand> validator)
        {
            _validator = validator;
        }

        public async Task<int> Handle(AddNewModelTypeCommand request, RequestHandlerDelegate<int> next, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(request, cancellationToken);
            if (validationResult.IsValid)
            {
               return  await next();
            }
            var result = await next();
            return result;
        }
    }
}
