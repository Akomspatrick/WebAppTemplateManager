using DocumentVersionManager.Application.CQRS.ModelType.Commands;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentVersionManager.Application.Validators
{
    public class AddModelTypeValidator : AbstractValidator<CreateModelTypeCommand>
    {
        public AddModelTypeValidator()
        {
            RuleFor(x => x.modelTypeCreateDTO).NotNull().NotEmpty();
            // RuleFor(x=>x.modelTypesName)..NotEmpty();
        }
    }
}
